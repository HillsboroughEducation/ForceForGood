using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace HillsboroughEducation.Models
{
    [Table("ScholarshipProfile")]
    public class ScholarshipModel
    {
        
        [Key]
        public int ScholarshipId { get; set; }

        [Required]
        [Display(Name = "Scholarship Name")]
        public string ScholarshipName { get; set; }

        [Required]
        [Display(Name = "Scholarship Type")]
        public string ScholarshipType { get; set; }

        [Required]
        [Display(Name = "Academic Year")]
        public string AcademicYear { get; set; }

        [Display(Name = "Number of Applicants")]
        public int NumOfApplicants { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public int Amount { get; set; }
    }
}