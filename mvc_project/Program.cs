using EF.Employees;
using EF.Projects;

var builder = WebApplication.CreateBuilder();
builder.Services.AddControllersWithViews();

// var app = builder.Build();
// app.MapControllerRoute(
//     name: "default",
//     //Добавили поддержку 3х сегментного запроса ИМЯ_КОНТРОЛЛЕРА/ИМЯ_МЕТОДА/НЕОБЯЗАТЕЛЬНЫЙ_ИДЕНТИФИКАТОР
//     //Чтобы обратиться контроллеру из веб-браузера, нам надо в адресной строке набрать адрес_сайта/Имя_контроллера/Действие_контроллера
//     pattern: "{controller=Home}/{action=Welcome}/{id?}");

// //Для доступа к Test/Index можно использовать просто /test
// app.MapControllerRoute(
//     name: "test",
//     pattern: "{controller=Test}/{action=Index}/{id?}");

// app.Run();

// Пример использования EF Core
using (ApplicationContext db = new ApplicationContext())
{
    // создаем два объекта User
    Project alpha = new Project { 
        Id = 1, 
        Name = "Alpha", 
        CompanyCustomer = "Pesos",
        CompanyExecutor = "Pizdos",
        // DateStart = new DateTime(2015, 7, 20),
        // DateEnd = new DateTime(2016, 7, 20),
        Priority = 10
    };

    Employee pepos = new Employee { 
        EmployeeId = 1, 
        Name = "Pepos", 
        Surname = "Pro", 
        Patronymic = "Max", 
        Email = "pepos@sobaka.ru", 
        Projects =  new List<Project?> {alpha}
    };

    
    // добавляем их в бд
    /*
        Метод Add устанавливает значение Added в качестве
        состояния нового объекта. Поэтому метод
        db.SaveChanges() сгенерирует выражение INSERT для
        вставки модели в таблицу.
    */
    db.Projects.Add(alpha);
    db.SaveChanges();
    Console.WriteLine("Объекты успешно сохранены");

    // получаем объекты из бд и выводим на консоль
    var projects = db.Projects.ToList();
    Console.WriteLine("Список объектов:");
    foreach (Project p in projects)
    {
        Console.WriteLine($"{p.Id}.{p.Name} - {p.CompanyExecutor}, {p.Priority}");
    }

    db.Employees.Add(pepos);
    db.SaveChanges();
    Console.WriteLine("Объекты успешно сохранены");

    // получаем объекты из бд и выводим на консоль
    var employees = db.Employees.ToList();
    Console.WriteLine("Список объектов:");
    foreach (Employee e in employees)
    {
        Console.WriteLine($"{e.EmployeeId}.{e.Name} - {e.Email}");
    }

    // Удаление производится с помощью метода Remove:
    /*
        Данный метод установит статус объекта в Deleted,
        благодаря чему Entity Framework при выполнении
        метода db.SaveChanges() сгенерирует SQL-выражение
        DELETE.
    */
    // db.Users.Remove(bob);
    // db.SaveChanges();
    // Console.WriteLine("Объекты успешно удалены");

    // users = db.Users.ToList();
    // Console.WriteLine("Список объектов:");
    // foreach (User u in users)
    // {
    //     Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    // }

    // Редактирование 
    /*
        При изменении объекта Entity Framework сам
        отслеживает все изменения, и когда вызывается метод
        SaveChanges(), будет сформировано SQL-выражение
        UPDATE для данного объекта, которое обновит объект в
        базе данных.
    */
    // User? user = db.Users.FirstOrDefault(u => u.Name=="Pepos");
    // Console.WriteLine($"Будет отредактирован объект: {user.Id}.{user.Name} - {user.Age}");
    // if (user != null)
    // {
    //     //обновляем объект
    //     user.Name = "Bob";
    //     user.Age = 44;
    //     db.SaveChanges();
    // }

    // users = db.Users.ToList();
    // Console.WriteLine("Список объектов:");
    // foreach (User u in users)
    // {
    //     Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    // }
}
// CRUD операции (Create, Read,
// Update, Delete)