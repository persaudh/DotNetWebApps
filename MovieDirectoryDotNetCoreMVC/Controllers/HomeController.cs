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
        private readonly IGenreService _genreService;
        private readonly IRatingService _ratingService;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService, IGenreService genreService, IRatingService ratingService)
        {
            _logger = logger;
            _movieService = movieService;
            _genreService = genreService;
            _ratingService = ratingService;
        }

        public IActionResult Index(List<int> genreIds, List<int> ratingIds)
        {
            var movies = _movieService.GetMoviesByGenreAndRatingAsync(genreIds,ratingIds).Result;

            var genres = _genreService.GetAllGenresAsync().Result;
            var ratings = _ratingService.GetAllRatingAsync().Result;

            var indexViewModel = new IndexViewModel
            {
                Movies = movies,
                Ratings = ratings,
                Genres = genres,
                SelectGenreIds = genreIds,
                SelectRatingIds = ratingIds
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
