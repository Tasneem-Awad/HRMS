using HRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS.DbContexts
{
    public class HRMSContext: DbContext
    {
        public HRMSContext(DbContextOptions<HRMSContext> options) : base(options)
        {
            //options:
            //database type:sql server
            //connection string
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Lookup>().HasData(
                new Lookup { id=1,magerCode=0,minerCode=0,name="Employees position"},
                new Lookup { id = 2, magerCode = 0, minerCode = 0, name = "Manager" },
                new Lookup { id = 3, magerCode = 0, minerCode = 1, name = "Developer" },
                new Lookup { id = 4, magerCode = 0, minerCode = 2, name = "HR" },
                new Lookup { id = 5, magerCode = 1, minerCode = 0, name = "Department name" },
                new Lookup { id = 6, magerCode = 1, minerCode = 1, name = "Finance" },
                new Lookup { id = 7, magerCode = 1, minerCode = 2, name = "Adminstrative" },
                new Lookup { id = 8, magerCode = 1, minerCode = 3, name = "Technical" }
                );
        }
        //Dbset--> tabels
        public DbSet<Employee> Employees {  get; set; }
        public DbSet <Department> Departments { get; set; }
        public DbSet<Lookup>Lookups { get; set; } 
    }
}
