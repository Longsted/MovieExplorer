using MovieExplorer.Application.Services;
using Microsoft.AspNetCore.Mvc;


namespace MovieExplorer.Web.Controllers;

public class GenresController : Controller
{
    private readonly GenreService _genreService;

    public GenresController(GenreService genreService)
    {
        _genreService = genreService;
    }

    public async Task<IActionResult> Index()
    {
        var genres = await _genreService.GetGenreAsync();
        return View(genres);
    }
}