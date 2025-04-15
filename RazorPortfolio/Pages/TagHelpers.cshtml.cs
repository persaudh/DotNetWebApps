using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RazorPortfolio.Pages
{
    public class TagHelpersModel : PageModel
    {
        public Employee Employee { get; set; }
        public List<Employee> Employees { get; set; }
        public void OnPost(Employee employee)
        {
            Console.WriteLine(employee.Name);
            Employees.Add(employee);

            ModelState.Clear();
        }
    }

    public class Employee
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [MinLength(12)]
        public string Password { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Send Monthly Newsletter")]
        public bool Newsletter { get; set; }
    }
}
