using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Models
{
    public class Employee //Model
    {
        public long id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string position { get; set; }
        public DateTime birthdate { get; set; }
        public string phone { get; set; }//+69279828,078
        public bool isActive { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public decimal? salary {  get; set; }
        [ForeignKey("Department")]
        public long? DepartmentId { get; set; }
        public Department? Department { get; set; }
        [ForeignKey("Manager")]
        public long? ManagerId { get; set; }
        public Employee? Manager { get; set; }
    }
}
