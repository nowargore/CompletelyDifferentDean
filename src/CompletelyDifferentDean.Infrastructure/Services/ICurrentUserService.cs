namespace CompletelyDifferentDean.Infrastructure.Services
{
    public interface ICurrentUserService
    {
        string UserId { get; }

        bool IsAuthenticated { get; }
    }
}