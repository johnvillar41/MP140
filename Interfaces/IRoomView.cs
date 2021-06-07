using MP140.Models;
using System.Collections.Generic;

namespace MP140.Interfaces
{
    public interface IRoomView
    {
        void DisplayProgressbar();
        void DisplayRooms(List<RoomModel> rooms);
        void HideProgressBar();
        void RedirectToTodoView(int roomID);
    }
}