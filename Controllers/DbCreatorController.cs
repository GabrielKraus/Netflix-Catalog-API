using Microsoft.AspNetCore.Mvc;
using Netflix_Catalog_API;

namespace Netflix_Catalog_API.Controllers;

[ApiController]
[Route("api/dbcreator")]

public class DbCreatorController: ControllerBase
{
    IDbCreatorService DbCreatorService;

    FilmsContext dbcontext;

    public DbCreatorController(IDbCreatorService dbCreator, FilmsContext db)
    {
        DbCreatorService = dbCreator;
        dbcontext = db;
    }
    

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(DbCreatorService.DbCreatedAknw());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();
        return Ok();
    }
}