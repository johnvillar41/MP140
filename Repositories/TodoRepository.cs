using MP140.Interfaces;
using MP140.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;

namespace MP140.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private static TodoRepository instance = null;
        private TodoRepository() { }
        public static TodoRepository SingleInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TodoRepository();
                }
                return instance;
            }
        }
        public void AddTodoItem(TodoModel newTodo)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTodoItem(int todoId)
        {
            throw new System.NotImplementedException();
        }

        public List<TodoModel> FetchAllTodosInARoom(int roomID)
        {
            throw new System.NotImplementedException();
        }

        public List<UserModel> FetchAllUsersInARoom(int roomID)
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