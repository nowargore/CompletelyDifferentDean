namespace CompletelyDifferentDean.Infrastructure.Timing;

public class UtcDateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.UtcNow;
}
