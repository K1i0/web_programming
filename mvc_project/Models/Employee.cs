using EF.Projects;

namespace EF.Employees {
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? Email { get; set; }
        public List<Project?> Projects { get; set; } // Навигационное свойство
    }
}