namespace Netflix_Catalog_API
{
    public class Films
    {
        public Guid FilmId {get;set;}
        public string Title {get;set;}
        public string Description {get;set;}
        public List<string> Genres {get;set;}
        public ClassType ClassType {get;set;}

        public string Duration {get;set;}
        public int AgeClassification{get;set;}
        public List<string> Direction {get;set;}
        public List<string> Cast {get;set;}
        public List<string> ScriptWriters {get;set;}
    }
    public enum ClassType
    {
        Series, Movie
    }
}