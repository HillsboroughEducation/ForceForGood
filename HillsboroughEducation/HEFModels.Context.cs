﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HillsboroughEducation
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
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
        public DbSet<Users> Users { get; set; }
        public DbSet<Criteria> Criteria { get; set; }
        public DbSet<Donors> Donors { get; set; }
        public DbSet<Eligible> Eligible { get; set; }
        public DbSet<Questions> Questions { get; set; }
    }
}