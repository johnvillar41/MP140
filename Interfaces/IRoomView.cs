using MP140.Models;
using System.Collections.Generic;

namespace MP140.Interfaces
{
    public interface IRoomView
    {
        void DisplayRooms(List<RoomModel> rooms);
    }
}