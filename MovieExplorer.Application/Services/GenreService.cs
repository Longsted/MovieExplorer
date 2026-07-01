using MovieExplorer.Application.Interfaces;
using MovieExplorer.Domain.Entities;
using MovieExplorer.Domain.Interfaces;

namespace MovieExplorer.Application.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;

    public GenreService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<IReadOnlyCollection<Genre>> GetGenreAsync()
    {
        return await  _genreRepository.GetGenreAsync();
    }
}