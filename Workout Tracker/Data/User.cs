using System.Runtime.ExceptionServices;

namespace WorkoutTracker.Data
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get { return $"{FirstName}_{LastName}"; } }
        public int? UserWorkoutPlanId { get; set; }

        public User() { }

        public User(int id, string firstName, string lastName, int? userWorkoutPlanId = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserWorkoutPlanId = userWorkoutPlanId;
        }
    }
}
