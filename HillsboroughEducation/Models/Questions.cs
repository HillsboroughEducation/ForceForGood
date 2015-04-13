using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HillsboroughEducation
{

    public partial class Questions
    {
        public bool QUESTION_SEQ { get; set; }
        public string DESCR { get; set; }
        public string SCHL_TYPE { get; set; }
        public Nullable<long> PREV_SEQ { get; set; }
        public Nullable<long> NEXT_SEQ { get; set; }
    }
}