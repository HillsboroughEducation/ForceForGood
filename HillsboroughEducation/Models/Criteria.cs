using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HillsboroughEducation.Models
{

    public class CriteriaContext : DbContext
    {
        public CriteriaContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Criteria> CriteriaProfiles { get; set; }
    }

    [Table("Criteria")]
    public class Criteria
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Criteria")]
        public string DESCR { get; set; }

        //public virtual Scholarships Scholarships { get; set; }
    }
}