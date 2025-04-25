using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Eyouth_APIs.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        [ForeignKey("Department")]
        public int deptId { get; set; }
        //[JsonIgnore]
        public Department Department { get; set; }
    }
}
