using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HillsboroughEducation
{

    public partial class Criteria
    {
        public long SCHL_SEQ { get; set; }
        public string DESCR { get; set; }
        public bool APPLICATION_IND { get; set; }
        public bool REQUIRED { get; set; }
        public bool ACTIVE { get; set; }

        public virtual Scholarships Scholarships { get; set; }
    }
}