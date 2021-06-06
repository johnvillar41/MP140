using MP140.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MP140.Interfaces
{
    public interface IRoomRepository
    {
        List<RoomModel> FetchAllRooms();
        void AddNewRoom(RoomModel newRoom);
        void DeleteRoom(int roomId);
    }
}