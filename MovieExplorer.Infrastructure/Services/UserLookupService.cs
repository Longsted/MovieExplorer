using Microsoft.AspNetCore.Identity;
using MovieExplorer.Application.Interfaces;
using MovieExplorer.Infrastructure.Persistence;

namespace MovieExplorer.Infrastructure.Services;

public class UserLookupService : IUserLookupService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserLookupService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string?> GetUsernameAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return user?.UserName;
    }
}