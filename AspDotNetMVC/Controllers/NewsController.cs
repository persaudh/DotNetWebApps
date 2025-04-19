using Microsoft.AspNetCore.Mvc;

namespace AspDotNetCoreMVC.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Atricle(string article)
        {
            return View();
        }
    }
}
