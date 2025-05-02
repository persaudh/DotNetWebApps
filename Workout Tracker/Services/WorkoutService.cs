using System.Security.Principal;
using WorkoutTracker.Data;

namespace WorkoutTracker.Services
{
    public class WorkoutService : IWorkoutService
    {
        private IWorkoutTrackerDbService _DbService { get; set; }
        public WorkoutService(IWorkoutTrackerDbService dbService)
        {
            _DbService = dbService;
        }

        public IEnumerable<Workout> GetAllWorkouts()
        {
            var workouts = _DbService.GetWorkouts();
            return workouts;
        }

        public Workout GetWorkoutById(int id)
        {
            var workouts = GetAllWorkouts();
            return workouts.Where(w => w.Id == id).FirstOrDefault();
        }

        public int AddWorkout(Workout workout)
        {
            var workouts = GetAllWorkouts();
            int maxid = workouts.Any() ?  workouts.Max(w => w.Id) : 0;
            workout.Id = maxid + 1;
            var UpdatedWorkouts = workouts.ToList();
            UpdatedWorkouts.Add(workout);
            workouts = UpdatedWorkouts.AsEnumerable();
            _DbService.UpdateWorkouts(workouts);
            return workout.Id;
        }
        public bool UpdateWorkout(Workout workout)
        {
            var workouts = GetAllWorkouts();
            var updatedList = workouts.ToList();
            foreach (var updatedWorkout in updatedList.Where(w => w.Id == workout.Id))
            {
                updatedWorkout.Rep = workout.Rep;
                updatedWorkout.DayOfTheWeek = workout.DayOfTheWeek;
                updatedWorkout.Description = workout.Description;
                updatedWorkout.Name = workout.Name;
                updatedWorkout.Sets = workout.Sets;
            }
            workouts = updatedList.AsEnumerable();
            _DbService.UpdateWorkouts(workouts);
            return true;
        }
        public bool DeleteWorkout(int id)
        {
            var workouts = GetAllWorkouts();
            var workout = workouts.Where(w => w.Id == id).FirstOrDefault();
            var updatedWorkouts = workouts.ToList();
            var delete = updatedWorkouts.Remove(workout);
            workouts = updatedWorkouts.AsEnumerable();
            _DbService.UpdateWorkouts(workouts);
            return delete;
        }


    }
}
