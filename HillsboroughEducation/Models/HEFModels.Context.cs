using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using HillsboroughEducation.Models;

namespace HillsboroughEducation.Models
{

    public partial class HEFEntities : DbContext
    {
        public HEFEntities()
            : base("name=HEFEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<Organizations> Organizations { get; set; }
        public DbSet<Reviewers> Reviewers { get; set; }
        public DbSet<Scholarships> Scholarships { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Criteria> Criteria { get; set; }
        public DbSet<Donors> Donors { get; set; }
        public DbSet<Eligible> Eligible { get; set; }
        public DbSet<Questions> Questions { get; set; }
    }
}