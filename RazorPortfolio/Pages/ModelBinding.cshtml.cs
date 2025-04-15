using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPortfolio.Pages
{
    public class ModelBindingModel : PageModel
    {
        public string UserName { get; set; } = string.Empty;
        //public void OnPost(string username, string password)
        //{
        //    UserName = username;
        //}
        public void OnPost(FormDate formData)
        {
            UserName = formData.UserName;
        }
    }

    public record FormDate(string UserName, string Password);
}
