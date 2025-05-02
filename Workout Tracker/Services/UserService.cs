using Microsoft.AspNetCore.Identity;
using WorkoutTracker.Data;

namespace WorkoutTracker.Services
{
    public class UserService : IUserService
    {
        private IWorkoutTrackerDbService _DbService;
        public UserService(IWorkoutTrackerDbService dbService)
        {
            _DbService = dbService;
        }
        public int AddUser(User user)
        {
            var users = GetAllUsers();
            int maxID = users.Any() ? users.Max(m => m.Id) : 0;
            user.Id = maxID + 1;
            var updatedList = users.ToList();
            updatedList.Add(user);
            users = updatedList.AsEnumerable();
            _DbService.UpdateUsers(users);
            return user.Id;
        }

        public bool DeleteUser(int id)
        {
            var users = GetAllUsers();
            var user = users.Where(u => u.Id == id).FirstOrDefault();
            var updatedList = users.ToList();
            bool deleted = updatedList.Remove(user);
            users = updatedList.AsEnumerable();
            _DbService.UpdateUsers(users);
            return deleted;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var allUsers = _DbService.GetUsers();
            return allUsers;
        }

        public User GetUserById(int id)
        {
            var users = GetAllUsers();
            var user = users.Where(users => users.Id == id).FirstOrDefault();
            return user;
        }

        public bool UpdateUser(User user)
        {
            var users = GetAllUsers();
            var updatedList = users.ToList();
            foreach(var u in updatedList.Where(us => us.Id == user.Id))
            {
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.UserWorkoutPlanId = u.UserWorkoutPlanId;
            }
            users = updatedList.AsEnumerable();
            _DbService.UpdateUsers(users);
            return true;
        }
    }
}
