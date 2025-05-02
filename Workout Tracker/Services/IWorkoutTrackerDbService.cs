using WorkoutTracker.Data;

namespace WorkoutTracker.Services
{
    public interface IWorkoutTrackerDbService
    {
        //public void CreateWorkoutTrackerDb();
        //public WorkoutTrackerDb GetWorkoutTrackerDb();
        public IEnumerable<Workout> GetWorkouts();
        public IEnumerable<WorkoutPlan> GetWorkoutPlans();
        public IEnumerable<User> GetUsers();
        public IEnumerable<UserPlan> GetUsersPlan();

        public void UpdateWorkouts(IEnumerable<Workout> workouts);

        public void UpdateWorkoutPlans(IEnumerable<WorkoutPlan> workoutPlans);
        public void UpdateUsers(IEnumerable<User> user);
        public void UpdateUsersPlan(IEnumerable<UserPlan> userPlan);
    }
}
