namespace HRMS.Dtos.Employee
{
    public class EmployeeDto
    {
        public long id { get; set; }
        public string name { get; set; }


        public string position { get; set; }
        public DateTime birthdate { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public long? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public long? ManagerId { get; set; }
        public string ManagerName { get; set; }



    }
}
