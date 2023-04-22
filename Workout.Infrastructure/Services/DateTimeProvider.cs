using Workout.Application.Common.Interfaces.Services;

namespace Workout.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}