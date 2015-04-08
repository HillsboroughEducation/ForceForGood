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
   
    [Table("ScholarshipProfile")]
    public class ScholarshipModel
    {

        [Key]
        public int ScholarshipId { get; set; }

        [Required]
        [Display(Name = "Scholarship Name")]
        public string ScholarshipName { get; set; }

        [Required]
        [Display(Name = "Scholarship Description")]
        public string ScholarshipDescription { get; set; }

        [Required]
        [Display(Name = "Scholarship Type")]
        public string ScholarshipType { get; set; }

        [Required]
        [Display(Name = "Academic Year")]
        public string AcademicYear { get; set; }

        [Display(Name = "Number of Applicants")]
        public int NumOfApplicants { get; set; }

        //NEEDS DATETIME
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Available")] 
        public string DateAvailable { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public int Amount { get; set; }

        [Required]
        [Display(Name = "Total Scholarship Funds")]
        public float TotalScholarshipFunds { get; set; }

        [Required]
        [Display(Name = "Length of Scholarship")]
        public string LengthOfScholarship { get; set; }

        //NEEDS DATETIME
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Deadline")]
        public string Deadline { get; set; }

        [Required]
        [Display(Name = "Number Awarded")]
        public int NumberAwared { get; set; }

        [Required]
        [Display(Name = "Amount Awarded")]
        public float AmountAwarededPerRecipient { get; set; }

        [Required]
        [Display(Name = "Number of Installments")]
        public int NumberofInstallments { get; set; }

        [Required]
        [Display(Name = "Amount Per Installment")]
        public float AmountPerInstallment { get; set; }

        [Required]
        [Display(Name = "Credit Required")]
        public string CreditsRequired { get; set; }

        [Required]
        [Display(Name = "GPA Required")]
        public float GPARequired { get; set; }

        // NEES TO BE BOOL FOR NEXT TWO
        [Required]
        [Display(Name = "Endowment")]
        public string Endowment { get; set; }

        [Required]
        [Display(Name = "Renewable")]
        public string Renewable { get; set; }

        //NEEDS DATETIME
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Reviewer Start Date")]
        public string ReviewerStartDate { get; set; }

        //NEEDS DATETIME
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Reviewer End Date")]
        public string ReviewerEndDate { get; set; }

        [Required]
        [Display(Name = "Selection:")]
        public string Selection { get; set; }

        [Required]
        [Display(Name = "Basis for Selection:")]
        public string BasisForSelection { get; set; }

        [Required]
        [Display(Name = "Approved Use of Funds:")]
        public string ApprovedUseOfFunds { get; set; }

        [Required]
        [Display(Name = "Disbursement:")]
        public string Disbursement { get; set; }

        [Required]
        [Display(Name = "How Often Awarded:")]
        public string HowOftenAwarded { get; set; }

        [Required]
        [Display(Name = "Presented")]
        public string Presented { get; set; }

        [Required]
        [Display(Name = "Script for the Awards Ceremonies:")]
        public string ScriptForAwardCeremony { get; set; }

        [Required]
        [Display(Name = "Comments:")]
        public string Comments { get; set; }
    }
}