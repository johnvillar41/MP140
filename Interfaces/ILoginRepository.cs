using MP140.Models;

namespace MP140.Interfaces
{
    public interface ILoginRepository
    {
        bool CheckUserLoggedIn(string username,  string password);
        void RegisterUser(UserModel newUser);
    }
}