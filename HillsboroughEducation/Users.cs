//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HillsboroughEducation
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public long USER_SEQ { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public Nullable<System.DateTime> LAST_LOGIN_DATE { get; set; }
        public Nullable<System.DateTime> PSWD_LAST_CHANGED { get; set; }
        public string STATUS { get; set; }
    }
}