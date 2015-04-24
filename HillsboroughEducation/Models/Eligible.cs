using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HillsboroughEducation
{

    public partial class Eligible
    {
        public string STUDENT_ID { get; set; }
        public long SCHL_SEQ { get; set; }
        public Nullable<bool> APPLIED { get; set; }
        public Nullable<System.DateTime> APPLIED_DATE { get; set; }

        public virtual Scholarships Scholarships { get; set; }
        public virtual Students Students { get; set; }
    }
}