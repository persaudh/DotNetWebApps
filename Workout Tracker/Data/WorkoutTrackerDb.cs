using System.Security.Cryptography;

namespace WorkoutTracker.Data
{
    public static class WorkoutTrackerDb
    {
        public static IEnumerable<Workout> _Workouts = new List<Workout>();
        public static IEnumerable<WorkoutPlan> _WorkOutPlans = new List<WorkoutPlan>();
        public static IEnumerable<User> _users = new List<User>();
        public static IEnumerable<UserPlan> _usersPlan = new List<UserPlan>();
        //public  WorkoutTrackerDb()
        //{
        //    _Workouts = new List<Workout>();
        //    _WorkOutPlans = new List<WorkoutPlan>();
        //    _users = new List<User>();
        //    _usersPlan = new List<UserPlan>();
        //}

    }
}
