namespace MvcApp.Models
{
    public record class Person(int Id, string Name, int Age, Company Work);
    public record class Company(int Id, string Name, string Country);
}