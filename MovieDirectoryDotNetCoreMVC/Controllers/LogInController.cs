using Microsoft.AspNetCore.Mvc;
using MovieDirectoryDotNetCoreMVC.Models;

namespace MovieDirectoryDotNetCoreMVC.Controllers
{
    public class LogInController : Controller
    {
        public IActionResult Index()
        {
            return View("LogIn");
        }

        public IActionResult LogIn()
        {
            return View("LogIn");
        }

        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public IActionResult SubmitLogIn(LogInViewModel model)
        {
            if(model.Equals(null) || string.IsNullOrEmpty(model.User.Username) || string.IsNullOrEmpty(model.User.Password))
            {
                model.ErrorMessage = "Username and password cannot be empty.";
                return View("LogIn", model);
            }
            return View("LogIn", model);
        }
    }
}