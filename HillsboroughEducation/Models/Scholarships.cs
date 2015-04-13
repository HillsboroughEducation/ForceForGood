using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HillsboroughEducation
{

    public partial class Scholarships
    {

        public long SCHL_SEQ { get; set; }
        public string TITLE { get; set; }
        public string DESCR { get; set; }
        public string TYPE { get; set; }
        public System.DateTime DATE_AVAILABLE { get; set; }
        public string AMOUNT_TYPE { get; set; }
        public long TOTAL_FUNDS { get; set; }
        public int LENGTH { get; set; }
        public System.DateTime DEADLINE { get; set; }
        public int NUMBER_AWARDED { get; set; }
        public int AMOUNT_PER_RECIPIENT { get; set; }
        public int NUMBER_INSTALLMENTS { get; set; }
        public int AMOUNT_PER_INSTALLMENT { get; set; }
        public int CREDITS_REQUIRED { get; set; }
        public Nullable<int> GPA_REQUIRED { get; set; }
        public Nullable<bool> ENDOWMENT_IND { get; set; }
        public Nullable<bool> RENEW_IND { get; set; }
        public Nullable<System.DateTime> REVIEW_START_DATE { get; set; }
        public Nullable<System.DateTime> REVIEW_END_DATE { get; set; }
        public string SELECTION { get; set; }
        public string SELECTION_BASIS { get; set; }
        public string APPROVED_USE_FUNDS { get; set; }
        public string DISBURSEMENT { get; set; }
        public Nullable<int> AWARD_FREQUENCY { get; set; }
        public string PRESENTED { get; set; }
        public string AWARD_SCRIPT { get; set; }
        public string COMMENTS { get; set; }

        public virtual ICollection<Criteria> Criteria { get; set; }
        public virtual ICollection<Eligible> Eligible { get; set; }
    }
}