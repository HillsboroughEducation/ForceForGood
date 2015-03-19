using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HillsboroughEducation.Models
{
    public class StudentFinancialModel
    {
        [Key]
        public int UserId { get; set; }

        public string FinancialNeedEligible { get; set; }

        public double AdjustedGrossIncome { get; set; }

        public int NumberInHousehold { get; set; }

        public string ReceivedSSCard { get; set; }
    }
}