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
    public async Task Save(Films film)
    {
        context.Add(film);
        await context.SaveChangesAsync();
    }
    public async Task Update(Guid id, Films film)
    {
        var filmActual = context.Films.Find(id);

        if (filmActual != null)
        {
            filmActual.GenreId = film.GenreId;
            filmActual.Title = film.Title;
            filmActual.Picture = film.Picture;
            filmActual.Description = film.Description;
            filmActual.ClassType = film.ClassType;
            filmActual.Duration = film.Duration;
            filmActual.AgeClassification = film.AgeClassification;
            filmActual.Direction = film.Direction;
            filmActual.Cast = film.Cast;
            filmActual.ScriptWriters = film.ScriptWriters;

            await context.SaveChangesAsync();
        }
    }
    public async Task Delete(Guid id)
    {
        var filmActual = context.Films.Find(id);

        if (filmActual != null)
        {
            context.Remove(filmActual);

            await context.SaveChangesAsync();
        }
    }
}
public interface IFilmsServices
{
    IEnumerable<Films> Get();
    Task Save(Films film);
    Task Update(Guid id, Films film);
    Task Delete(Guid id);
}
