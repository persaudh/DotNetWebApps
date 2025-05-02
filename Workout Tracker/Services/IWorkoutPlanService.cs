using WorkoutTracker.Data;

namespace WorkoutTracker.Services
{
    public interface IWorkoutPlanService
    {
        public IEnumerable<WorkoutPlan> GetAllWorkoutPlans();
        public WorkoutPlan GetWorkoutPlanById(int id);
        public int AddWorkoutPlan(WorkoutPlan plan);
        public bool UpdateWorkoutPlan(WorkoutPlan plan);
        public bool DeleteWorkoutPlan(int id);

    }
}
