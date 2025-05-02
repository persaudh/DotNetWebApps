namespace WorkoutTracker.Data
{
    public class WorkoutPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Workout> Workouts { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int Duration { get; set; }

        public WorkoutPlan() { }

        public WorkoutPlan(int id, string name, List<Workout> workouts, DateOnly startDate, DateOnly endDate, int duration)
        {
            Id = id;
            Name = name;
            Workouts = workouts;
            StartDate = startDate;
            EndDate = endDate;
            Duration = duration;
        }
    }
}
