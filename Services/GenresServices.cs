using Netflix_Catalog_API.Models;

namespace Netflix_Catalog_API.Services;

public class GenresServices: IGenresServices
{
    FilmsContext context;
    public GenresServices(FilmsContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Genres>  Get()
    {
        return context.Genres;
    }

}
public interface IGenresServices
{
    IEnumerable<Genres> Get();

}