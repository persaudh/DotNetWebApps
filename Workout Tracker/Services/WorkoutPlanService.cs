using WorkoutTracker.Data;

namespace WorkoutTracker.Services
{
    public class WorkoutPlanService : IWorkoutPlanService
    {
        private IWorkoutTrackerDbService _DbService { get; set; }
        public WorkoutPlanService(IWorkoutTrackerDbService dbService)
        {
            _DbService = dbService;
        }

        public int AddWorkoutPlan(WorkoutPlan plan)
        {
            var workoutplans = GetAllWorkoutPlans();
            int maxID = workoutplans.Any() ? workoutplans.Max(w => w.Id): 0;
            plan.Id = maxID + 1;
            var updatedWorkoutPlan = workoutplans.ToList();
            updatedWorkoutPlan.Add(plan);
            workoutplans = updatedWorkoutPlan.AsEnumerable();
            _DbService.UpdateWorkoutPlans(workoutplans);
            return plan.Id ;
        }

        public bool DeleteWorkoutPlan(int id)
        {
            var workoutplans = GetAllWorkoutPlans();
            var workoutplan = workoutplans.Where(x => x.Id == id).FirstOrDefault();
            var updatedWorkoutPlans = workoutplans.ToList();
            var delete = updatedWorkoutPlans.Remove(workoutplan);
            workoutplans = updatedWorkoutPlans.AsEnumerable();
            _DbService.UpdateWorkoutPlans(workoutplans);
            return delete;
        }

        public IEnumerable<WorkoutPlan> GetAllWorkoutPlans()
        {
            var workoutPlans = _DbService.GetWorkoutPlans();
            return workoutPlans;
        }

        public WorkoutPlan GetWorkoutPlanById(int id)
        {
            var workoutplans = GetAllWorkoutPlans();
            var workoutplan = workoutplans.Where(w => w.Id == id).FirstOrDefault();
            return workoutplan;
        }

        public bool UpdateWorkoutPlan(WorkoutPlan plan)
        {
            var workoutplans = GetAllWorkoutPlans();
            var updatedWorkoutPlans = workoutplans.ToList();
            foreach (var workoutPlan in updatedWorkoutPlans.Where(w => w.Id == plan.Id))
            {
                workoutPlan.Workouts = plan.Workouts;
                workoutPlan.Duration = plan.Duration;
                workoutPlan.StartDate = plan.StartDate;
                workoutPlan.EndDate = plan.EndDate;
            }
            workoutplans = updatedWorkoutPlans.AsEnumerable();
            _DbService.UpdateWorkoutPlans(workoutplans);
            return true;
        }
    }
}
