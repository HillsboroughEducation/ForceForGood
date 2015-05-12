using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HillsboroughEducation.Models
{

    public class DonorContext : DbContext {
        public DonorContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Donors> DonorProfiles { get; set; }
    }

    [Table("Donors")]
    public class Donors
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Donor Name")]
        public string NAME { get; set; }

        [Required]
        [Display(Name = "Donor City")]
        public string CITY { get; set; }

        [Required]
        [Display(Name = "Donor State")]
        public string STATE { get; set; }

        [Required]
        [Display(Name = "Donor Zipcode")]
        public int ZIP { get; set; }
    }
}