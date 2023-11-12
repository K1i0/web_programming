using EF.Employees;

namespace EF.Projects
{
    public class Project
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CompanyCustomer { get; set; }
        public string? CompanyExecutor { get; set; }
        public List<Employee?> Executors { get; set; }
        // public DateTime DateStart { get; set; }
        // public DateTime DateEnd { get; set; }

        public int Priority { get; set; }
    }
}