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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://192.168.1.105/TodoPhp/login.php?username={username}&password={password}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            var result = reader.ReadToEnd();
            using JsonDocument doc = JsonDocument.Parse(result);
            JsonElement root = doc.RootElement;
            var u1 = root[0];
            if (u1.ToString().Equals("OK!"))
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