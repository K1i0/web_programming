// namespace MvcApp.Models
// {
//     // Анемичная модель не имеет поведения
//     // и хранит только состояние в виде свойств.
//     public class Person {
//         public string Name {get; set; }
//         public int Age { get; set; }
//     }

//     // В языке C# для представления подобных моделей удобно
//     // использовать классы record:
//     public record class TestPerson(int Id, string Name, int Age);

//     // Fat Model. мы можем уйти от анемичной модели, добавив
//     // к ней какое-нибудь поведение: 
//     public class FatPerson
//     {
//         public int Id { get; set; }
//         public string Name { get; set; }
//         public int Age { get; set; }
//         public FatPerson(int id, string name, int age)
//         {
//             Id = id;
//             Name = name;
//             Age = age;
//         }
//         public string PrintInfo() => $"{Id}. {Name} ({Age})";
//     }

//     /*
//     В приложении ASP.NET MVC Core модели можно разделить
//     по степени применения на несколько групп:
//     •Модели, объекты которых хранятся в специальных
//     хранилищах данных (например, в базах данных, файлах
//     xml и т. д.)
//     •Модели, которые используются для передачи данных
//     представление или наоборот, для получения данных из
//     представления. Такие модели еще называются моделями
//     представления
//     •Вспомогательные модели для промежуточных вычислений
//     */
// }