using MP140.Models;
using System.Collections.Generic;

namespace MP140.Interfaces
{
    public interface ITodoRepository
    {
        void AddTodoItem(TodoModel newTodo,int roomID);
        void DeleteTodoItem(int todoId);
        List<TodoModel> FetchAllTodosInARoom(int roomID);
        List<UserModel> FetchAllUsersInARoom(int roomID);
    }
}