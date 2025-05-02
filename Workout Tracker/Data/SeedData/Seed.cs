using WorkoutTracker.Services;

namespace WorkoutTracker.Data.SeedData
{
    public class Seed
    {
        public IUserPlanService UserPlanService { get; set; }
        public IWorkoutPlanService WorkoutPlanService { get; set; }
        public IWorkoutService WorkoutService { get; set; }
        public IUserService UserService { get; set; }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            int count = 10;
            SeedUsers(count, serviceProvider);
        }

        public static void SeedUsers(int count,IServiceProvider serviceProvider )
        {
            using var scope = serviceProvider.CreateScope();
            var userService = scope.ServiceProvider.GetService<IUserService>();

            for (int i = 0; i < count; i++)
            {
                User user = new User();
                user.FirstName = $"FirstName{i}";
                user.LastName = $"LastName{i}";
                userService.AddUser(user);
            }
        }

        public static void SeedWorkouts(int count, IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            var workoutService = scope.ServiceProvider.GetService<IWorkoutService>();

            for(int i = 0; i < count; i++)
            {
                var workout = new Workout();
                

            }
        }
    }
}
