using Microsoft.AspNetCore.Mvc;
using Netflix_Catalog_API.Models;
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
    [HttpPost]
    public IActionResult Post([FromBody] Genres genre)
    {
        genresServices.Save(genre);
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Genres genre)
    {
        genresServices.Update(id, genre);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        genresServices.Delete(id);
        return Ok();
    }
}