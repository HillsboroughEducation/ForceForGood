using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HillsboroughEducation.Models
{
    public class ScholarshipCriteriaContext : DbContext
    {
        public ScholarshipCriteriaContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<ScholarshipCriteria> ScholarshipCriteriaProfiles { get; set; }
    }

    [Table("ScholarshipCriteria")]
    public class ScholarshipCriteria
    {
        public int ID { get; set; }
        public int SCHOLARSHIP_ID { get; set; }
        public int CRITERIA_ID { get; set; }
    }

    public class ScholarshipCriteriaModel
    {
        public ScholarshipModel scholarships { get; set; }
        public List<Criteria> criterias { get; set; }
    }
}