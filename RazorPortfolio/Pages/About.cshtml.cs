using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPortfolio.Pages
{
    public class AboutModel : PageModel
    {
        public IList<string> ProgrammingLanguages { get; set; } = new List<string>(); 
        public void OnGet()
        {
            ProgrammingLanguages.Add("C#");
            ProgrammingLanguages.Add("JavaScript");
            ProgrammingLanguages.Add("Python");
            ProgrammingLanguages.Add("Java");
            ProgrammingLanguages.Add("HTML/CSS");
            ProgrammingLanguages.Add("SQL");
        }
    }
}
