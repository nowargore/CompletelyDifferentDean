using CompletelyDifferentDean.Dto;
using Microsoft.AspNetCore.Identity;

namespace CompletelyDifferentDean.Application;

public static class DtoExtensions
{
    public static async Task<T> MakeReadableLastModifiedBy<T>(this T dto, UserManager<IdentityUser> userManager) where T : AuditableDto
    {
        var user = await userManager.FindByIdAsync(dto.LastModifiedBy);

        if (user != null)
            dto.LastModifiedBy = user.UserName;

        return dto;
    }
}
