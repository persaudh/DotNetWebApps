using WorkoutTracker.Data;

namespace WorkoutTracker.Services
{
    public class WorkoutTrackerDbService : IWorkoutTrackerDbService
    {
        //public void CreateWorkoutTrackerDb()
        //{
        //    WorkoutTrackerDb = new WorkoutTrackerDb();
        //}
        //public WorkoutTrackerDb GetWorkoutTrackerDb()
        //{
        //    return WorkoutTrackerDb;
        //}

        public IEnumerable<Workout> GetWorkouts()
        {
            return WorkoutTrackerDb._Workouts;
        }

        public IEnumerable<WorkoutPlan> GetWorkoutPlans()
        {
            return WorkoutTrackerDb._WorkOutPlans;
        }

        public IEnumerable<User> GetUsers()
        {
            return WorkoutTrackerDb._users;
        }

        public void UpdateWorkouts(IEnumerable<Workout> workouts)
        {
            WorkoutTrackerDb._Workouts = workouts;
        }

        public void UpdateWorkoutPlans(IEnumerable<WorkoutPlan> workoutPlans)
        {
            WorkoutTrackerDb._WorkOutPlans = workoutPlans;
        }

        public void UpdateUsers(IEnumerable<User> user)
        {
            WorkoutTrackerDb._users = user;
        }

        public IEnumerable<UserPlan> GetUsersPlan()
        {
            return WorkoutTrackerDb._usersPlan;
        }

        public void UpdateUsersPlan(IEnumerable<UserPlan> userPlan)
        {
            WorkoutTrackerDb._usersPlan = userPlan;
        }
    }
}
