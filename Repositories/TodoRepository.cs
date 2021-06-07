using MP140.Interfaces;
using MP140.Models;
using System;
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
        public void AddTodoItem(TodoModel newTodo,int roomID)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{Constants.ROOT_URL}AddTodoItem.php?todoTitle={newTodo.Title}&todoDescription={newTodo.Description}&DateStarted={newTodo.DateStarted.ToString("yyyy-dd-MM:G")}&Status={newTodo.Status}&userID={UserSession.UserID}&roomID={roomID}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using StreamReader reader = new StreamReader(response.GetResponseStream());
        }
        public void DeleteTodoItem(int todoId)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{Constants.ROOT_URL}DeleteTodoItem.php?todoID={todoId}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using StreamReader reader = new StreamReader(response.GetResponseStream());
        }

        public List<TodoModel> FetchAllTodosInARoom(int roomID)
        {
            List<TodoModel> todoModels = new List<TodoModel>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{Constants.ROOT_URL}FetchTodosInAGivenRoom.php?roomID={roomID}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using StreamReader reader = new StreamReader(response.GetResponseStream());
            var res = reader.ReadToEnd();
            using JsonDocument doc = JsonDocument.Parse(res);
            JsonElement root = doc.RootElement;
            for (int i = 0; i < root.GetArrayLength(); i++)
            {
                var todoItem = new TodoModel
                {
                    Id = int.Parse(root[i].GetProperty("Todo_ID").ToString()),
                    Title = root[i].GetProperty("Title").ToString(),
                    Description = root[i].GetProperty("Description").ToString(),
                    DateStarted = DateTime.Parse(root[i].GetProperty("Date_Created").ToString())                   
                };
                if (root[i].GetProperty("Status").ToString().Equals(nameof(Constants.Status.Doing)))
                    todoItem.Status = Constants.Status.Doing;
                if (root[i].GetProperty("Status").ToString().Equals(nameof(Constants.Status.Done)))
                    todoItem.Status = Constants.Status.Done;
                if (root[i].GetProperty("Date_Finished").ToString().Length != 0)
                    todoItem.DateFinished = DateTime.Parse(root[i].GetProperty("Date_Finished").ToString());
                else
                    todoItem.DateFinished = null;
                todoModels.Add(todoItem);
            }
            return todoModels;
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