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

    public class FinancialContext : DbContext 
    {
        public FinancialContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<StudentFinancialModel> FinancialInfoProfiles { get; set; }
    }

    [Table("FinancialInfoProfile")]
    public class StudentFinancialModel
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "Financial Need Eligible")]
        public string FinancialNeedEligible { get; set; }

        [Display(Name = "Adjusted Gross Income")]
        public double AdjustedGrossIncome { get; set; }

        [Display(Name = "Number in Household")]
        public int NumberInHousehold { get; set; }

        [Display(Name = "Received Social Security Card?")]
        public string ReceivedSSCard { get; set; }
    }
}