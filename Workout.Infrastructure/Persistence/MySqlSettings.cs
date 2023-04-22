namespace Workout.Infrastructure.Persistence;

public class MySqlSettings
{
    public const string SectionName = "MySqlSettings";

    public string ConnectionString { get; init; } = null!;
}