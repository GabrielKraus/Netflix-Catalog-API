using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
namespace Netflix_Catalog_API.Models;

public class Genres
{
    public Guid GenreId {get;set;}
    public string Genre {get;set;}
    
    [JsonIgnore]
    public virtual ICollection<Films> Films {get;set;}
}
