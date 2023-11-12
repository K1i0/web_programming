using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;
using MvcApp.Users;

namespace MvcApp.Controllers
{

    public class TestController : Controller
    {
        // Вызов представления
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexView()
        {
            return View("~/Views/Test/TestView.cshtml");
        }

        // Передача данных из контроллера в пердставление
        // ViewData, позволяет передавать простые объекты, вроде string, int...
        public IActionResult TransportViewData()
        {
            // Здесь динамически определяется во ViewData объект с
            // ключом "Message" и значением "Hello, world!". При этом в
            // качестве значения может выступать любой объект.
            ViewData["Message"] = "Hello, world! (Transport)";
            return View("~/Views/Test/TransportData.cshtml");
        }

        // ViewBag, позволяет передавать сложные данные, например, список
        public IActionResult TransportViewBag()
        {
            ViewBag.People = new List<string> { "Tom", "Sam", "Bob" };
            return View("~/Views/Test/TransportData.cshtml");
        }

        // Для передачи данных в представление используется одна из версий метода View
        public IActionResult TransportViewModel()
        {
            var people = new List<string> { "Tom", "Sam", "Bob" };
            return View("~/Views/Test/TransportModel.cshtml", people);
        }

        // http://localhost:5048/Test/AddUser?name=Tom
        // http://localhost:5048/Test/AddUser?name=Tom&Id=1
        // public string AddUser(User user)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         return $"Id: {user.Id} Name: {user.Name} Age: {user.Age} HasRight: {user.HasRight}";
        //     }
        //     string errors = $"Количество ошибок: {ModelState.ErrorCount}. Ошибки в свойствах: ";
        //     foreach (var prop in ModelState.Keys)
        //     {
        //         errors = $"{errors}{prop}; ";
        //     }
        //     return errors;
        // }

        /*
        Если для свойства с атрибутом BindRequired не будет
        передано значение, то в объект ModelState, который
        представляет словарь, будет помещена информация об
        ошибках, а свойство ModelState.IsValid возвратит false. И в
        данном случае, проверяя значение ModelState.IsValid, мы
        можем проверить корректность создания объекта User. При
        этом все ключи в словаре ModelState будут представлять
        свойства, в которых произошли ошибки.
        */
    }
}