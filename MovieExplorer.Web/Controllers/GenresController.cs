using Microsoft.AspNetCore.Mvc;
using MovieExplorer.Application.Interfaces;


namespace MovieExplorer.Web.Controllers;

public class GenresController : Controller
{
    private readonly IGenreService _genreService;

    public GenresController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    public async Task<IActionResult> Index()
    {
        var genres = await _genreService.GetGenreAsync();
        return View(genres);
    }
}