namespace Eyouth_APIs.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MgrName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
