namespace MovieDirectoryDotNetCoreMVC.Models
{
    public class LogInViewModel
    {
        public User User { get; set; } = new User();
        public string ErrorMessage { get; set; } = string.Empty;
        public LogInViewModel() { }
        public LogInViewModel(User user)
        {
            User = user;
        }
    }


    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
