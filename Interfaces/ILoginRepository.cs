namespace MP140.Interfaces
{
    public interface ILoginRepository
    {
        bool CheckUserLoggedIn(string username,  string password);
    }
}