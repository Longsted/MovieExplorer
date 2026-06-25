using MovieExplorer.Domain.Entities;

namespace MovieExplorer.Domain.Interfaces;

public interface IGenreRepository
{
    Task<List<Genre>> GetGenreAsync();
}