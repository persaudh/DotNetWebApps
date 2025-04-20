using AspDotNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AspDotNetCoreMVC.Data;
using AspDotNetCoreMVC.Filters;

namespace AspDotNetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonService _personService;

        public HomeController(ILogger<HomeController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return ViewComponent("TopProducts", new { count = 10 });
        }

        // /home/person
        public IActionResult Person()
        {
            var persons = _personService.GetAll();
            var viewModel = new PersonViewModel(persons.First());
            ViewData["LuckyNumber"] = 20;
            ViewBag.HomeAddress = "123 Main St, Springfield, USA";

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult BlogPost()
        {
            return View();
        }

        public IActionResult ToDo()
        {
            return View();
        }

        [HttpPost]
        [ValidateModel]
        public IActionResult Create(TodoItem item)
        {
            return Ok($"Item '{item.Text}' created.");
        }
    }
}
