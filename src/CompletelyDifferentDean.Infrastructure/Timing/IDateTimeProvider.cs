namespace CompletelyDifferentDean.Infrastructure.Timing;

public interface IDateTimeProvider
{
    DateTime Now { get; }
}
