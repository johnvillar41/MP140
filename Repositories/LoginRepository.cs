using MP140.Interfaces;
using MP140.Models;
using System;
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
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{Constants.ROOT_URL}login.php?username={username}&password={password}");
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using StreamReader reader = new StreamReader(response.GetResponseStream());
                var res = reader.ReadToEnd();
                using JsonDocument doc = JsonDocument.Parse(res);
                JsonElement root = doc.RootElement;
                if (root[0].ToString().Length != 0)
                {
                    UserSession.UserID = int.Parse(root[0].GetProperty("User_ID").ToString());
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }            
            
        }

        public void RegisterUser(UserModel newUser)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{Constants.ROOT_URL}register.php?username={newUser.Username}&password={newUser.Password}&fullname={newUser.Fullname}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using StreamReader reader = new StreamReader(response.GetResponseStream());

        }
    }
}