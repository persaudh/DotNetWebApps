using WorkoutTracker.Data;

namespace WorkoutTracker.Services
{
    public interface IWorkoutService
    {
        public IEnumerable<Workout> GetAllWorkouts();
        public Workout GetWorkoutById(int id);
        public int AddWorkout(Workout workout);
        public bool UpdateWorkout(Workout workout);
        public bool DeleteWorkout(int id);
    }
}
