using MP140.Models;
using System.Collections.Generic;

namespace MP140.Interfaces
{
    public interface ITodoRepository
    {
        void AddTodoItem(TodoModel newTodo);
        void DeleteTodoItem(int todoId);
        List<TodoModel> FetchAllTodos();
    }
}