using MP140.Interfaces;
using MP140.Models;
using System.Collections.Generic;

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
    }
}