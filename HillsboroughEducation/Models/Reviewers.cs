using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HillsboroughEducation.Models
{

    public class ReviewerContext : DbContext
    {
        public ReviewerContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Reviewers> ReviewerProfiles { get; set; }
    }

    [Table("Reviewers")]
    public partial class Reviewers
    {
        public long USER_SEQ { get; set; }

        [Required]
        [Display(Name = "Academic Year")]
        public string ACADEMIC_YEAR { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FIRST_NAME { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LAST_NAME { get; set; }

        [Display(Name = "Country")]
        public string COUNTRY { get; set; }

        [Display(Name = "Gender")]
        public string GENDER { get; set; }

        [Display(Name = "Address 1")]
        public string ADDRESS_LINE1 { get; set; }

        [Display(Name = "Address 2")]
        public string ADDRESS_LINE2 { get; set; }

        [Display(Name = "City")]
        public string CITY { get; set; }

        [Display(Name = "State")]
        public string STATE { get; set; }

        [Display(Name = "County")]
        public string COUNTY { get; set; }

        [Display(Name = "Postal Code")]
        public Nullable<int> POSTAL_CODE { get; set; }

        [Display(Name = "Home Phone")]
        public string HOME_PHONE { get; set; }

        [Display(Name = "Work Phone")]
        public string WORK_PHONE { get; set; }

        [Display(Name = "Cell Phone")]
        public string CELL_PHONE { get; set; }

        [Display(Name = "Email")]
        public string EMAIL { get; set; }

        [Display(Name = "Notes")]
        public string NOTES { get; set; }

        [Display(Name = "Bad Email")]
        public Nullable<bool> BAD_EMAIL { get; set; }

        [Display(Name = "Org Seq")]
        public Nullable<int> ORG_SEQ { get; set; }

        [Required]
        [Display(Name = "Reviewer ID")]
        [Key]
        public int REVIEWER_ID { get; set; }
    }
}