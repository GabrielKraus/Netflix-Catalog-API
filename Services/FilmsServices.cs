using Netflix_Catalog_API.Models;

namespace Netflix_Catalog_API.Services;

public class FilmsServices: IFilmsServices
{
    FilmsContext context;
    public FilmsServices(FilmsContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Films>  Get()
    {
        return context.Films;
    }

}
public interface IFilmsServices
{
    IEnumerable<Films> Get();

}
