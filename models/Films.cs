using System.Text.Json.Serialization;

namespace Netflix_Catalog_API.Models;

public class Films
{
    public Guid FilmId {get;set;}
    public Guid GenreId {get;set;}
    public string Title {get;set;}
    public string Picture {get;set;}
    public string Description {get;set;}
    public ClassType ClassType {get;set;}
    public string Duration {get;set;}
    public int AgeClassification{get;set;}
    public string Direction {get;set;}
    public string Cast {get;set;}
    public string ScriptWriters {get;set;}
    [JsonIgnore]
    public virtual Genres Genres {get;set;}
}
public enum ClassType
{
    Series, Movie
}
