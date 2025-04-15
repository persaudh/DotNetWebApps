using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPortfolio.Pages
{
    public class ArticalModel : PageModel
    {
        public string? Title { get; set; }
        public string? Text { get; set; }
        public void OnGet(int articalId)
        {
            switch (articalId)
            {
                case 1:
                    Title = "New Website!";
                    Text = "Welcome.";
                    break;
                case 2:
                    Title = "New Customer!";
                    Text = "We have a new customer.";
                    break;
                case 3:
                    Title = "New Artical!";
                    Text = "This is the best artical.";
                    break;
            }
        }
    }
}
