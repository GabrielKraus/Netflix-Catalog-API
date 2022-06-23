using Microsoft.EntityFrameworkCore;
using Netflix_Catalog_API.Models;

namespace Netflix_Catalog_API;

public class FilmsContext: DbContext
{   
    public DbSet<Genres> Genres{get;set;}
    public DbSet<Films> Films{get;set;}
    

    public FilmsContext(DbContextOptions<FilmsContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Genres> genresInit = new List<Genres>();
        genresInit.Add(new Genres(){GenreId = Guid.Parse("3c2d0c12-612d-443e-a69d-77f2e0db1f39"), Genre = "Comedias romanticas"});
        genresInit.Add(new Genres(){GenreId = Guid.Parse("aef228a9-5902-4bc3-99e1-74a3fe526437"), Genre = "Comedias"});
        genresInit.Add(new Genres(){GenreId = Guid.Parse("66adbe21-5950-4236-8c00-8666f99f7bff"), Genre = "Cine romantico"});

        modelBuilder.Entity<Genres>(genre =>
        {   
            genre.ToTable("Genres");
            genre.HasKey(p=> p.GenreId);
            genre.Property(p=> p.Genre).HasMaxLength(100);

            genre.HasData(genresInit);
        });


        List<Films> filmsInit = new List<Films>();
        filmsInit.Add(new Films() { 
            FilmId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), 
            GenreId = Guid.Parse("3c2d0c12-612d-443e-a69d-77f2e0db1f39"), 
            Title = "Mi novia Polly", 
            Picture = "https://images-na.ssl-images-amazon.com/images/S/pv-target-images/9290b804c6794110c584a62ade71e39c8247d120473d92cc8b36ccf4f52fca8e._RI_V_TTW_.jpg",
            BrandLogo = "https://occ-0-2416-420.1.nflxso.net/dnm/api/v6/tx1O544a9T7n8Z_G12qaboulQQE/AAAABQ3oIQkJZ2dZzuVRpPJGvlNgivCCdIyHy74pGmMJJtRXU3lS585qTOYAeK3KAhskqx3R9jyyGOn2xS3rGG-GAped1gCvE7V0R8ue2WhDA-k.webp?r=1af",
            BackgroundPic = "https://occ-0-2416-420.1.nflxso.net/dnm/api/v6/E8vDc_W8CLv7-yMQu8KMEC7Rrr8/AAAABULmRYiVPxrNT7M32nwJGjwI6krkX0OfOQDCWgC8C6dE6tAaqmDl7T4ODjTmm23l7Cfsdep4yBUbMEtaGMCjzi38IHcuLTc05yFE.webp?r=525",
            Description = "Después de ser abandonado por su esposa en la luna de miel, el mojigato Reuben se reencuentra con una irreverente amiga de la infancia que le enseña a vivir al límite.", 
            ClassType= ClassType.Movie, 
            Duration = "1:30", 
            AgeClassification=13,
            Direction = "John Hamburg", 
            Cast = "Ben Stillerm Jennifer Aniston, Philip Seymour Hoffman, Debra Messing, Alec Baldwin, Hank Azaria, Bryan Brown, Jsun Garcia", 
            ScriptWriters = "John Hamburg" 
        });



        modelBuilder.Entity<Films>(film=>
        {
            film.ToTable("Films");
            film.HasKey(p=> p.FilmId);
            film.HasOne(p=> p.Genres).WithMany(p=> p.Films).HasForeignKey(p=> p.GenreId);
            film.Property(p=> p.Title);
            film.Property(p=> p.Picture);
            film.Property(p=> p.BrandLogo);
            film.Property(p=> p.BackgroundPic);
            film.Property(p=> p.Description);
            film.Property(p=> p.ClassType);
            film.Property(p=> p.Duration);
            film.Property(p=> p.AgeClassification);
            film.Property(p=> p.Direction);
            film.Property(p=> p.Cast);
            film.Property(p=> p.ScriptWriters);

            film.HasData(filmsInit);

        });

    }

};