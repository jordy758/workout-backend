using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Workout.Domain.ExerciseAggregate;
using Workout.Domain.UserAggregate;
using Workout.Domain.WorkoutPlanAggregate;

namespace Workout.Infrastructure.Persistence;

public class WorkoutDbContext : DbContext
{
    public WorkoutDbContext(DbContextOptions<WorkoutDbContext> options) : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<Exercise> Exercises { get; set; } = null!;
    public virtual DbSet<WorkoutPlan> WorkoutPlans { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}