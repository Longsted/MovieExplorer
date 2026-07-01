using MovieExplorer.Domain.Entities;

namespace MovieExplorer.Application.Interfaces;

public interface IGenreService
{
    public Task<IReadOnlyCollection<Genre>> GetGenreAsync();
    
    

}