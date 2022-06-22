
public class DbCreatorService: IDbCreatorService 
{
    public string DbCreatedAknw()
    {
        return "Database Created!";
    }
}

public interface IDbCreatorService
{
    string DbCreatedAknw();
}
