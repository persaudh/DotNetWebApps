using WorkoutTracker.Data;

namespace WorkoutTracker.Services
{
    public class UserPlanService : IUserPlanService
    {
        private IWorkoutTrackerDbService _workoutTrackerDbService;
        public UserPlanService(IWorkoutTrackerDbService dbService)
        {
            _workoutTrackerDbService = dbService;
        }

        public IEnumerable<UserPlan> GetUserPlans()
        {
            var userPlans = _workoutTrackerDbService.GetUsersPlan();
            return userPlans;
        }

        public int AddUserPlan(UserPlan userPlan)
        {
            var userPlans = GetUserPlans();
            var maxId = userPlans.Any() ? userPlans.Max(x => x.Id) : 0;
            userPlan.Id = maxId + 1;
            var updatedUserPlans = userPlans.ToList();
            updatedUserPlans.Add(userPlan);
            userPlans = updatedUserPlans.AsEnumerable();
            _workoutTrackerDbService.UpdateUsersPlan(userPlans);
            return userPlan.Id;
        }

        public bool UpdateUserPlan(UserPlan userPlan)
        {
            var userPlans = GetUserPlans();
            var updatedUserPlans = userPlans.ToList();
            foreach(var up in updatedUserPlans.Where(u => u.Id == userPlan.Id))
            {
                up.WorkoutPlanId = userPlan.WorkoutPlanId;
            }
            userPlans = updatedUserPlans.AsEnumerable();
            _workoutTrackerDbService.UpdateUsersPlan(userPlans);
            return true;
        }
    }
}
