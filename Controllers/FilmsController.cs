using Microsoft.AspNetCore.Mvc;
using Netflix_Catalog_API.Models;
using Netflix_Catalog_API.Services;

namespace Netflix_Catalog_API.Controllers;

[Route("api/films")]
public class FilmsController : ControllerBase
{
    IFilmsServices filmsService;

    public FilmsController(IFilmsServices service)
    {
        filmsService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(filmsService.Get());
    }
    [HttpPost]
    public IActionResult Post([FromBody] Films film)
    {
        filmsService.Save(film);
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Films film)
    {
        filmsService.Update(id, film);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        filmsService.Delete(id);
        return Ok();
    }
}