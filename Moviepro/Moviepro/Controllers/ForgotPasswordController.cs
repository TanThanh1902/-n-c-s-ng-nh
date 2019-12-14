using Moviepro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Moviepro.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net;

namespace Moviepro.Controllers
{
    public class ForgotPasswordController : Controller
    {
        DBMovieEntities db = new DBMovieEntities();
        // GET: ForgotPassword
        public ActionResult SendEmail()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(EmployeeModel obj)
        {

            try
            {
                //Configuring webMail class to send emails  
                //gmail smtp server  
                WebMail.SmtpServer = "smtp.gmail.com";
                //gmail port to send emails  
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = true;
                //sending emails with secure protocol  
                WebMail.EnableSsl = true;
                //EmailId used to send emails from application  
                WebMail.UserName = "hatanthanh190299@gmail.com";
                WebMail.Password = "0949287875";
                TSql_Informations info = db.TSql_Informations.SingleOrDefault(t => t.UserName == obj.ToEmail);
                //Sender email address.  
                WebMail.From = "hatanthanh190299@gmail.com";
                obj.EmailSubject = "Reset Password";
                obj.EMailBody = "<a href='https://localhost:44343/ForgotPassword/ResetPassword/" + info.IDInfo + "?token=" + info.ForgotPasswordCode  + "'>Reset Password</a>";
                //Send email  
                WebMail.Send(to: obj.ToEmail, subject: obj.EmailSubject, body: obj.EMailBody, cc: obj.EmailCC, bcc: obj.EmailBCC, isBodyHtml: true);
                ViewBag.Status = "Email Sent Successfully.";
            }
            catch (Exception)
            {
                ViewBag.Status = "Problem while sending email, Please check details.";
            }
            return View();
        }
        public async Task<ActionResult> ResetPassword(int? id, string token)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Informations tSql_Informations = await db.TSql_Informations.FindAsync(id);
            Session["fgpw"] = tSql_Informations;
            if (tSql_Informations == null)
            {
                return HttpNotFound();
            }
            return View(tSql_Informations);
        }

        // POST: Admin/TSql_Informations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> ResetPassword([Bind(Include = "IDInfo,DisplayName,UserName,Password,Role,ConfirmPassword")] TSql_Informations tSql_Informations)
        {
            if(tSql_Informations.Password != tSql_Informations.ConfirmPassword)
            {
                ViewBag.Status = "Password incorrect";
                return View();
            }
            if (ModelState.IsValid)
            {
                tSql_Informations.ForgotPasswordCode = Guid.NewGuid().ToString();
                db.Entry(tSql_Informations).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            Session["user"] = Session["flag"] = Session["fgpw"];
            Session["ffgpw"] = null;
            return View();
        }
    }
}