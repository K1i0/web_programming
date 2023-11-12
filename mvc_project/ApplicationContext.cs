using Microsoft.EntityFrameworkCore;

using EF.Employees;
using EF.Projects;
// DbContext: определяет контекст данных, используемый для
// взаимодействия с базой данных
public class ApplicationContext : DbContext
{
    // DbSet/DbSet<TEntity>: представляет набор объектов,
    // которые хранятся в базе данных:
    public DbSet<Employee> Employees => Set<Employee>(); // Набор объектов User == таблица Users
    public DbSet<Project> Projects => Set<Project>();
    public ApplicationContext() => Database.EnsureCreated();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // DbContextOptionsBuilder: устанавливает параметры
        // подключения
        optionsBuilder.UseNpgsql(@"Host=localhost;
                                   Port=5432;
                                   Database=projectsdb;
                                   Username=postgres;
                                   Password=password");
    }
}

/*
    Взаимодействие с базой данных в Entity Framework Core
    происходит посредством специального класса -
    контекста данных. Поэтому добавим в наш проект новый
    класс, который назовем ApplicationContext .
*/