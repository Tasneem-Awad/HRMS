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
        //Dbset--> tabels
        public DbSet<Employee> Employees {  get; set; }
        public DbSet <Department> Departments { get; set; }
    }
}
