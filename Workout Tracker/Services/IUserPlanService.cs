using WorkoutTracker.Data;

namespace WorkoutTracker.Services
{
    public interface IUserPlanService
    {
        public IEnumerable<UserPlan> GetUserPlans();
        public int AddUserPlan(UserPlan userPlan);
        public bool UpdateUserPlan(UserPlan userPlan);
    }
}
