using MP140.Interfaces;
using MP140.Models;
using System.IO;
using System.Net;
using System.Text.Json;
namespace MP140.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private static LoginRepository instance = null;
        private LoginRepository() { }
        public static LoginRepository SingleInstance
        {
            get
            {
                if(instance == null)
                {
                    instance = new LoginRepository();
                }
                return instance;
            }
        }

        public bool CheckUserLoggedIn(string username, string password)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{Constants.ROOT_URL}login.php?username={username}&password={password}");
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using StreamReader reader = new StreamReader(response.GetResponseStream());
            string res = reader.ReadToEnd();
            if (res.Contains("OK!"))
            {
                return true;
            }
            return false;      
        }

        public void RegisterUser(UserModel newUser)
        {
            throw new System.NotImplementedException();
        }
    }
}