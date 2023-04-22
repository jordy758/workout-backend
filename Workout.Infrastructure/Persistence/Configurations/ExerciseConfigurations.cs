using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workout.Domain.ExerciseAggregate;
using Workout.Domain.ExerciseAggregate.ValueObjects;

namespace Workout.Infrastructure.Persistence.Configurations;

public class ExerciseConfigurations : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        ConfigureExercisesTable(builder);
    }

    private void ConfigureExercisesTable(EntityTypeBuilder<Exercise> builder)
    {
        builder.ToTable("Exercises");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ExerciseId.Create(value));

        builder.Property(e => e.Name)
            .HasMaxLength(50);

        builder.Property(e => e.Description)
            .HasMaxLength(350);

        builder.Property(e => e.TargetedMuscles)
            .HasConversion(
                value => string.Join(',', value),
                value => value.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                new ValueComparer<IReadOnlyList<string>>(
                    (c1, c2) => (c1 == null && c2 == null) || (c1 != null && c2 != null && c1.SequenceEqual(c2)),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()));

        builder.Property(e => e.TargetedMuscles).Metadata.SetField("_targetedMuscles");
    }
}