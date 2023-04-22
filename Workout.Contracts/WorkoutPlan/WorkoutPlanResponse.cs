namespace Workout.Contracts.WorkoutPlan;

public record WorkoutPlanResponse(
    Guid Id,
    string Name,
    string Description,
    IEnumerable<WorkoutPlanSectionResponse> Sections);