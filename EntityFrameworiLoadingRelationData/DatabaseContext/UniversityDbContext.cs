using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworiLoadingRelationData.Models;

namespace EntityFrameworiLoadingRelationData.DatabaseContext
{
    public class UniversityDbContext: DbContext
    {
        public UniversityDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
