//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moviepro.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TSql_Film_Category
    {
        public int IDFilm_Category { get; set; }
        public int IDFilm { get; set; }
        public int IDCategory { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public Nullable<System.DateTime> DateUpdate { get; set; }
    
        public virtual TSql_Categorys TSql_Categorys { get; set; }
        public virtual TSql_Films TSql_Films { get; set; }
    }
}
