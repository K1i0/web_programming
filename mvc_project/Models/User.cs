using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MvcApp.Users
{
    // public class User
    // {
    //     public int Id { get; set; }

    //     // При передаче в запросе объекта User, наличие атрибута Name - обязательно
    //     [BindRequired]
    //     public string Name { get; set; } = "";

    //     public int Age { get; set; }
    //     // А вот атрибут HasRight - игнорируется, чтобы "из вне" нельзя было получить права доступа, например
    //     [BindNever]
    //     public bool HasRight { get; set; }
    // }
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}
