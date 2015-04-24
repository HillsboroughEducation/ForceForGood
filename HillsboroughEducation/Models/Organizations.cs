using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HillsboroughEducation
{

    public partial class Organizations
    {
        public long ORG_SEQ { get; set; }
        public string NAME { get; set; }
        public string ADDRESS_LINE1 { get; set; }
        public string ADDRESS_LINE2 { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public int POSTAL_CODE { get; set; }
    }
}