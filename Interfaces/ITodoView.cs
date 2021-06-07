using MP140.Models;
using System.Collections.Generic;

namespace MP140.Interfaces
{
    public interface ITodoView
    {
        void DisplayProgressBar();
        void HideProgressBar();
        void DisplayTodosInAGivenRoom(List<TodoModel> todoModels);
        void DisplayUsersInAGivenRoom(List<UserModel> userModels);
    }
}