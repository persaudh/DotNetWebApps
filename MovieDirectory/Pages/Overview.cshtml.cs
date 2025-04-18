using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieDirectory.Services;
using System.Diagnostics.Contracts;

namespace MovieDirectory.Pages
{
    public class OverviewModel : PageModel
    {
        private readonly IMovieService _movieService;
        [BindProperty]
        public Movie NewMovie { get; set; }
        [BindProperty]
        public int MovieId { get; set; }
        [BindProperty]
        public Movie EditableMovie { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();

        public OverviewModel(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public void OnGet()
        {
            GetAllMovies();
        }

        public void GetAllMovies()
        {
            Movies = _movieService.GetMoviesAsync().Result;
        }

        public async Task<IActionResult> OnPostAddMovieAsync()
        {
            //if (ModelState.IsValid)
            //{
                await _movieService.AddMovieAsync(NewMovie);
                ModelState.Clear();
                GetAllMovies();
                return RedirectToPage();
            //}
            //GetAllMovies();
            //return Page();
        }

        public async Task<IActionResult> OnPostEditMovieAsync(int id)
        {
            var movies = await _movieService.GetMoviesAsync();
            EditableMovie = movies.FirstOrDefault(m => m.Id == id);
            MovieId = EditableMovie.Id;

            GetAllMovies();
            return Page();
        }

        public async Task<IActionResult> OnPostSaveEditAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _movieService.UpdateMovieAsync(EditableMovie);
                if (result)
                {
                    return RedirectToPage();
                }
            }
            return RedirectToPage();
        }

        public IActionResult OnPostCancelEdit()
        {
            GetAllMovies();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteMovieAsync(int id)
        {
            var result = await _movieService.DeleteMovieAsync(id);
            GetAllMovies();
            return RedirectToPage();
        }
    }
}
