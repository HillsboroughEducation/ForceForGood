using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace HillsboroughEducation.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<StudentModel> StudentProfiles { get; set; }
        public DbSet<StudentFinancialModel> FinancialInfoProfiles { get; set; }
        public DbSet<ScholarshipModel> ScholarshipProfiles { get; set; }
    }
   
    
    [Table("StudentProfile")]
    public class StudentModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Academic Year")]
        public string AcademicYear { get; set; }

        [Required]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name:")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Social Security #(Last 4 digits only):")]
        public int SocialSecurity { get; set; }

        [Required]
        [Display(Name = "Country:")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Gender:")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Ethnicity:")]
        public string Ethnicity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Address:")]
        public string Address1 { get; set; }

        [Required]
        [Display(Name = "Second Address:")]
        public string Address2 { get; set; }

        [Required]
        [Display(Name = "Student ID:")]
        public string StudentNumber { get; set; }

        [Required]
        [Display(Name = "City:")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State:")]
        public string State { get; set; }

        [Required]
        [Display(Name = "County:")]
        public string County { get; set; }

        [Required]
        [Display(Name = "Postal Code:")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Home Phone:")]
        public string HomePhone { get; set; }

        [Required]
        [Display(Name = "Work Phone:")]
        public string WorkPhone { get; set; }

        [Required]
        [Display(Name = "Cell Phone:")]
        public string CellPhone { get; set; }

        [Required]
        [Display(Name = "Email/Username:")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Notes:")]
        public string Notes { get; set; }
        
        // STRING NEEDS TO BE BOOL BUT HAS ERROR WITH PAGE.
        [Required]
        [Display(Name = "Bad Email Address")]
        public string BadEmailAddress { get; set; }

        [Required]
        [Display(Name = "Received Thank You Letter")]
        public string ReceivedLetter { get; set; }   
    }
}