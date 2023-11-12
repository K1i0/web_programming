using MvcApp.Models;
namespace MvcApp.ViewModels
{
    public record class CompanyModel(int Id, string Name);
    
    public class IndexViewModel
    {
        public IEnumerable<Person> People { get; set; } = new List<Person>();
        public IEnumerable<CompanyModel> Companies { get; set; } = new List<CompanyModel>();
    }
}