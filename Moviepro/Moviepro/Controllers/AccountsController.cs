using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Moviepro.Models;

namespace Moviepro.Controllers
{
    public class AccountsController : Controller
    {
        DBMovieEntities db = new DBMovieEntities();
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }
        // Creat new account
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(TSql_Informations user)
        {
            if(ModelState.IsValid)
            {
                user.ForgotPasswordCode = Guid.NewGuid().ToString();
                user.DateCreate = DateTime.Now;
                db.TSql_Informations.Add(user);
                db.SaveChanges();
                Session["user"] = Session["flag"] = user;
            }
            return Redirect("/Home/Index");
        }
        // Check accout have exist
        [HttpPost]
        public JsonResult CheckUser(string UserName)
        {
            bool isExist = db.TSql_Informations.SingleOrDefault(t => t.UserName == UserName) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }
        // Login your account
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(FormCollection f)
        {
            string sUs = f["txtUserName"].ToString();
            string sPs = f["txtPassword"].ToString();
            TSql_Informations info_user = db.TSql_Informations.Where(t => t.Role == 0).SingleOrDefault(t => t.UserName == sUs && t.Password == sPs);
            TSql_Informations info_ad1 = db.TSql_Informations.Where(t => t.Role == 1).SingleOrDefault(t => t.UserName == sUs && t.Password == sPs);
            TSql_Informations info_ad2 = db.TSql_Informations.Where(t => t.Role == 2).SingleOrDefault(t => t.UserName == sUs && t.Password == sPs);
            if(info_user != null)
            {
                Session["flag"] = info_user;
                Session["user"] = info_user;
            }
            if (info_ad1 != null)
            {
                Session["flag"] = info_ad1;
                Session["ad"] = info_ad1;
                Session["ad1"] = info_ad1;
            }
            if (info_ad2 != null)
            {
                Session["flag"] = info_ad2;
                Session["ad"] = info_ad2;
                Session["ad2"] = info_ad2;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        // Logout your acccout
        public ActionResult SignOut()
        {
            Session["user"] = Session["ad1"] = Session["ad2"] = Session["flag"]  = Session["ad"] = null;
            return Redirect("/Home/Index");
        }

        public ActionResult SendEmail()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string receiver, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("hatanthanh190299@gmail.com", "Lucy Mr.Prince");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "0949287875";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }
    }
}