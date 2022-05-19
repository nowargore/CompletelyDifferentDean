namespace CompletelyDifferentDean.Infrastructure.Timing;

public static class Clock
{
    private static IDateTimeProvider _provider;

    static Clock()
    {
        _provider = new UtcDateTimeProvider();
    }

    public static DateTime Now => _provider.Now;

    /// <summary>
    /// Sets IDateTimeProvider for Clock.
    /// </summary>
    /// <remarks>Default provider is UtcDateTimeProvider.</remarks>
    public static void SetProvider(IDateTimeProvider provider)
    {
        _provider = provider;
    }
}
