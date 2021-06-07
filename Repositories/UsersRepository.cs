using MP140.Interfaces;
using MP140.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;

namespace MP140.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private static UsersRepository instance = null;
        private UsersRepository() { }
        public static UsersRepository SingleInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UsersRepository();
                }
                return instance;
            }
        }
        public List<UserModel> FetchAllUsersInAGivenRoom(int roomID)
        {
            List<UserModel> userModels = new List<UserModel>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{Constants.ROOT_URL}fetchAllUsersInAGivenRoom.php?roomID={roomID}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using StreamReader reader = new StreamReader(response.GetResponseStream());
            var res = reader.ReadToEnd();
            using JsonDocument doc = JsonDocument.Parse(res);
            JsonElement root = doc.RootElement;
            for (int i = 0; i < root.GetArrayLength(); i++)
            {
                userModels.Add(
                        new UserModel
                        {
                            Id = int.Parse(root[i].GetProperty("User_ID").ToString()),
                            Username = root[i].GetProperty("Username").ToString(),
                            Fullname = root[i].GetProperty("Fullname").ToString()
                        }
                    );
            }
            return userModels;
        }
    }
}