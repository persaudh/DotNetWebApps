using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPortfolio.Pages
{
    public class CoursesModel : PageModel
    {
        public IList<Course> Courses { get; set; } = new List<Course>();
        public void OnGet()
        {
            Courses.Add(new Course("TC#/.NET Bootcamp: Full-Stack Web Development (w/ ASP.NET Core and Blazor)",
                "15 Hours", "https://academy.zerotomastery.io/courses/enrolled/2025735"));
            Courses.Add(new Course("AWS Certified Cloud Practitioner: Zero to Mastery)",
                "10 Hours", "https://academy.zerotomastery.io/courses/enrolled/1710861"));
            Courses.Add(new Course("Complete Web Developer in 2025: Zero to Mastery)",
                "40 Hours", "https://academy.zerotomastery.io/courses/enrolled/697434"));
            Courses.Add(new Course("The Complete Junior to Senior Web Developer Roadmap (2025)",
                "37 Hours", "https://academy.zerotomastery.io/courses/enrolled/700470"));
            Courses.Add(new Course("Complete SQL + Databases Bootcamp: Zero to Mastery)",
                "40 Hours", "https://academy.zerotomastery.io/courses/enrolled/1073491"));
            Courses.Add(new Course("JavaScript: The Advanced Concepts",
                "27 Hours", "https://academy.zerotomastery.io/courses/enrolled/698487"));
        }
    }

    public class Course
    {
        public string Name { get; set; }
        public string Duration { get; set; }

        public string URL { get; set; }
        public Course(string name, string duration, string url)
        {
            Name = name;
            Duration = duration;
            URL = url;
        }
    }
}
