using Microsoft.Extensions.Options;
using System.Runtime.InteropServices;

namespace HRMS.Models
{
    public class Department
    {
        public long id {  get; set; }
        public String name {  get; set; }   
        public String description {  get; set; }
        public int ? floorNumber {  get; set; }

    }
}
