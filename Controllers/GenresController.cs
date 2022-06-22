using Microsoft.AspNetCore.Mvc;
using Netflix_Catalog_API.Services;

namespace Netflix_Catalog_API.Controllers;

[Route("api/genres")]
public class GenresController : ControllerBase
{
    IGenresServices genresServices;
    public GenresController(IGenresServices service)
    {
        genresServices = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(genresServices.Get());
    }
}