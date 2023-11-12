using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;
using MvcApp.ViewModels;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        List<Company> companies = new List<Company> 
        {
            new Company(123, "Pochta", "Russia"),
            new Company(456, "Pesos", "Russia")
        };
        List<Person> people = new List<Person>
        {
            new Person(1, "Tom", 37, new Company(123, "Pochta", "Russia")),
            new Person(2, "Bob", 41, new Company(123, "Pochta", "Russia")),
            new Person(3, "Sam", 28, new Company(456, "Pesos", "Russia"))
        };

        // [HttpGet, ActionName("Welcome")]
        [ActionName("Welcome")]
        public string Index()
        {
            return "Hello World!";
        }

        // http://localhost:5048/Home/Index?name=Tom&age=37.
        //print Name: Tom Age: 37
        // public string Index(string name, int age)
        // {
        //     return $"Name: {name} Age: {age}";
        // }

        // http://localhost:5048/Home/Index
        public IActionResult Index(int? companyId)
        {
            // формируем список компаний для передачи в представление (выпадающий список)
            // Id - для фильтрации, Name - для отображения в представлении (выпадающий список)
            List<CompanyModel> compModels = companies
            .Select(c => new CompanyModel(c.Id, c.Name)).ToList();
            // добавляем на первое место
            compModels.Insert(0, new CompanyModel(0, "Все"));
            IndexViewModel viewModel = new() { Companies = compModels, People = people };
            // если передан id компании (не "Все"), фильтруем список
            if (companyId != null && companyId > 0)
                viewModel.People = people.Where(p => p.Work.Id == companyId);
            return View(viewModel);
        }
    }
}