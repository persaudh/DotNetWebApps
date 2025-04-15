using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPortfolio.Services;

namespace RazorPortfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ILuckyNumberService _numberService;

        public int LuckuNumber { get; set; }
        public string UserName { get; set; } = string.Empty;

        public IndexModel(ILogger<IndexModel> logger, ILuckyNumberService luckyNumberService)
        {
            _logger = logger;
            _numberService = luckyNumberService;
        }

        public void OnPost()
        {
            UserName = Request.Form["username"];
        }

        public PageResult OnGet()
        {
            LuckuNumber = _numberService.GetMyLuckyNumber();

            return Page();

        }
    }
}
