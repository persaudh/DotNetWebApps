using Microsoft.AspNetCore.Mvc;
using MovieDirectoryDotNetCoreMVC.Models;
using MovieDirectoryDotNetCoreMVC.Services;
using System.Diagnostics;

namespace MovieDirectoryDotNetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            var movies = _movieService.GetAllMoviesAsync().Result;
            var indexViewModel = new IndexViewModel
            {
                Movies = movies
            };
            return View(indexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
