using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace HillsboroughEducation.Models
{
    public class ScholarshipContext : DbContext {
        public ScholarshipContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<ScholarshipModel> ScholarshipProfiles { get; set; }
    }
   
    [Table("Scholarships")]
    public class ScholarshipModel
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string TITLE { get; set; }

        public string DESCR { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string TYPE { get; set; }

        [Required]
        [Display(Name = "Date")]
        public System.DateTime DATE_AVAILABLE { get; set; }

        [Required]
        [Display(Name = "Applicant Amount")]
        public string AMOUNT_TYPE { get; set; }

        [Required]
        [Display(Name = "Total Funds")]
        public long TOTAL_FUNDS { get; set; }

        [Required]
        [Display(Name = "Length")]
        public int LENGTH { get; set; }

        [Required]
        [Display(Name = "Deadline")]
        public System.DateTime DEADLINE { get; set; }

        [Required]
        [Display(Name = "Number Awarded")]
        public int NUMBER_AWARDED { get; set; }

        [Required]
        [Display(Name = "Amount Per Recipient")]
        public int AMOUNT_PER_RECIPIENT { get; set; }

        [Required]
        [Display(Name = "Number of Installments")]
        public int NUMBER_INSTALLMENTS { get; set; }

        [Required]
        [Display(Name = "Amount Per Installment")]
        public int AMOUNT_PER_INSTALLMENT { get; set; }

        [Required]
        [Display(Name = "Credits Required")]
        public int CREDITS_REQUIRED { get; set; }

        [Display(Name = "GPA Required")]
        public Nullable<int> GPA_REQUIRED { get; set; }

        [Display(Name = "Endowment")]
        public Nullable<bool> ENDOWMENT_IND { get; set; }

        [Display(Name = "Renew")]
        public Nullable<bool> RENEW_IND { get; set; }

        [Display(Name = "Review Start Date")]
        public Nullable<System.DateTime> REVIEW_START_DATE { get; set; }

        [Display(Name = "Review End Date")]
        public Nullable<System.DateTime> REVIEW_END_DATE { get; set; }


        [Display(Name = "Selection")]
        public string SELECTION { get; set; }

        [Display(Name = "Selection Basis")]
        public string SELECTION_BASIS { get; set; }

        [Display(Name = "Approved Use Funds")]
        public string APPROVED_USE_FUNDS { get; set; }

        [Display(Name = "Disbursement")]
        public string DISBURSEMENT { get; set; }
        public Nullable<int> AWARD_FREQUENCY { get; set; }

        [Display(Name = "Presented")]
        public string PRESENTED { get; set; }

        [Display(Name = "Award Script")]
        public string AWARD_SCRIPT { get; set; }

        [Display(Name = "Comments")]
        public string COMMENTS { get; set; }

        public virtual ICollection<Criteria> Criteria { get; set; }
    }
}