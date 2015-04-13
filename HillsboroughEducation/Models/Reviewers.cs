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
        public string COUNTRY { get; set; }
        public string GENDER { get; set; }
        public string ADDRESS_LINE1 { get; set; }
        public string ADDRESS_LINE2 { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string COUNTY { get; set; }
        public Nullable<int> POSTAL_CODE { get; set; }
        public string HOME_PHONE { get; set; }
        public string WORK_PHONE { get; set; }
        public string CELL_PHONE { get; set; }
        public string EMAIL { get; set; }
        public string NOTES { get; set; }
        public Nullable<bool> BAD_EMAIL { get; set; }
        public Nullable<int> ORG_SEQ { get; set; }

        [Key]
        public int REVIEWER_ID { get; set; }
    }
}