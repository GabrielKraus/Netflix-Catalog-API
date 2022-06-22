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

    public async Task Save(Genres genre)
    {
        context.Add(genre);
        await context.SaveChangesAsync();
    }
    public async Task Update(Guid id, Genres genre)
    {
        var genreActual = context.Genres.Find(id);

        if(genreActual != null)
        {
            genreActual.Genre = genre.Genre;
            await context.SaveChangesAsync();
        }
    }
    public async Task Delete(Guid id)
    {
        var genreActual = context.Genres.Find(id);

        if(genreActual != null)
        {
            context.Remove(genreActual);
            await context.SaveChangesAsync();
        }
    }
}
public interface IGenresServices
{
    IEnumerable<Genres> Get();
    Task Save(Genres genre);
    Task Update(Guid id, Genres genre);
    Task Delete(Guid id);
}