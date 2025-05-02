namespace WorkoutTracker.Data
{
    public class UserPlan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkoutPlanId { get; set; }

        public UserPlan()
        {

        }
        public UserPlan(int id, int userId, int workoutPlanId)
        {
            Id = id;
            UserId = userId;
            WorkoutPlanId = workoutPlanId;
        }
    }
}
