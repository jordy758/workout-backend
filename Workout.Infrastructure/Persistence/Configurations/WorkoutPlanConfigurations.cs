using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workout.Domain.Exercise.ValueObjects;
using Workout.Domain.WorkoutPlan;
using Workout.Domain.WorkoutPlan.ValueObjects;

namespace Workout.Infrastructure.Persistence.Configurations;

public class WorkoutPlanConfigurations : IEntityTypeConfiguration<WorkoutPlan>
{
    public void Configure(EntityTypeBuilder<WorkoutPlan> builder)
    {
        ConfigureWorkoutPlansTable(builder);
        ConfigureWorkoutSectionsTable(builder);
    }

    private void ConfigureWorkoutPlansTable(EntityTypeBuilder<WorkoutPlan> builder)
    {
        builder.ToTable("WorkoutPlans");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => WorkoutPlanId.Create(value));

        builder.Property(u => u.Name)
            .HasMaxLength(50);
        
        builder.Property(u => u.Description)
            .HasMaxLength(350);
    }
    
    private void ConfigureWorkoutSectionsTable(EntityTypeBuilder<WorkoutPlan> builder)
    {
        builder.OwnsMany(w => w.Sections, sb =>
        {
            sb.ToTable("WorkoutPlanSections");
            sb.WithOwner().HasForeignKey("WorkoutPlanId");
            sb.HasKey("Id", "WorkoutPlanId");

            sb.Property(s => s.Id)
                .HasColumnName("WorkoutSectionId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => WorkoutPlanSectionId.Create(value));

            sb.Property(s => s.Name)
                .HasMaxLength(50);

            sb.Property(s => s.Description)
                .HasMaxLength(350);

            sb.OwnsMany(s => s.Exercises, eb =>
            {
                eb.ToTable("WorkoutPlanExercises");

                eb.WithOwner().HasForeignKey("WorkoutSectionId", "WorkoutId");

                eb.Property(e => e.Id)
                    .HasColumnName("WorkoutPlanExerciseId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => WorkoutPlanExerciseId.Create(value));
                
                eb.Property(e => e.ExerciseId)
                    .HasConversion(
                        id => id.Value,
                        value => ExerciseId.Create(value));

                eb.Property(e => e.Description)
                    .HasMaxLength(350);

                eb.Property(e => e.Sets);
                eb.Property(e => e.Reps);
            });
            
            sb.Navigation(s => s.Exercises).Metadata.SetField("_exercises");
            sb.Navigation(s => s.Exercises).UsePropertyAccessMode(PropertyAccessMode.Field);
        });
        
        builder.Metadata.FindNavigation(nameof(WorkoutPlan.Sections))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}