namespace MovieExplorer.Application.Interfaces;

public interface IUserLookupService
{
    Task<string?> GetUsernameAsync(string userId);
}