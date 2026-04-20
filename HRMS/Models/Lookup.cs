using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Lookup
    {
        public long id {  get; set; }
        public int magerCode { get; set; }
        public int minerCode { get; set; }
        [MaxLength(50)]
        public string name { get; set; }
    }
}
