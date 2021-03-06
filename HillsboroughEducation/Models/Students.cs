﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HillsboroughEducation
{

    public partial class Students
    {

        public long USER_SEQ { get; set; }
        public string STUDENT_ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public Nullable<int> SSN4 { get; set; }
        public string COUNTRY { get; set; }
        public string GENDER { get; set; }
        public string ETHNICITY { get; set; }
        public System.DateTime DOB { get; set; }
        public string ADDRESS_LINE_1 { get; set; }
        public string ADDRESS_LINE_2 { get; set; }
        public int ACADEMIC_YEAR { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string COUNTY { get; set; }
        public int POSTAL_CODE { get; set; }
        public string HOME_PHONE { get; set; }
        public string WORK_PHONE { get; set; }
        public string CELL_PHONE { get; set; }
        public string EMAIL { get; set; }
        public string NOTES { get; set; }
        public Nullable<bool> BAD_EMAIL { get; set; }
        public Nullable<bool> RECEIVED_THANK_YOU { get; set; }
        public Nullable<bool> FINANCIAL_NEED_ELIGIBLE { get; set; }
        public Nullable<int> ADJUSTED_GROSS_INCOME { get; set; }
        public Nullable<int> NUMBER_IN_HOUSEHOLD { get; set; }
        public Nullable<bool> RECEIVED_SSN_COPY { get; set; }
        public Nullable<long> TOTAL_AWARD { get; set; }

        public virtual ICollection<Eligible> Eligible { get; set; }
    }
}