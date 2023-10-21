//Класс контекста - для взаимодействия с СУБД
using Microsoft.EntityFrameworkCore;

namespace HelloApp
{
	public class ApplicationContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		public ApplicationContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb2;Username=postgres;Password=password");
		}
	}
}