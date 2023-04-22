namespace Workout.Application.Common.Interfaces.Persistence;

public interface IWorkoutPlanRepository
{
    Task AddAsync(Domain.WorkoutPlanAggregate.WorkoutPlan workoutPlan);
    Task<IEnumerable<Domain.WorkoutPlanAggregate.WorkoutPlan>> GetAllAsync();
}