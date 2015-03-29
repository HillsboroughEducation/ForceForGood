using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HillsboroughEducation.Models
{
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