using WorkoutTracker.Data;

namespace WorkoutTracker.Services
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUserById(int id);
        public int AddUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(int id);
    }
}
