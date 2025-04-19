using AspDotNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetCoreMVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
