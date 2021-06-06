using MP140.Interfaces;
using MP140.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MP140.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private static RoomRepository instance = null;
        private RoomRepository() { }
        public static RoomRepository SingleInstance
        {
            get
            {
                if(instance == null)
                {
                    instance = new RoomRepository();
                }
                return instance;
            }
        }

        public void AddNewRoom(RoomModel newRoom)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteRoom(int roomId)
        {
            throw new System.NotImplementedException();
        }

        public List<RoomModel> FetchAllRooms()
        {
            return new List<RoomModel>
            {
                new RoomModel
                {
                    Id = 1,
                    RoomName = "Math",
                    RoomDescription = "HUEHEUHEUEUE",
                    RoomType = Constants.RoomType.Academics
                },
                new RoomModel
                {
                    Id = 2,
                    RoomName = "Science",
                    RoomDescription = "HUEHEUHEUEUE",
                    RoomType = Constants.RoomType.Academics
                },
                new RoomModel
                {
                    Id = 3,
                    RoomName = "HEHHEE",
                    RoomDescription = "HUEHEUHEUEUE",
                    RoomType = Constants.RoomType.Academics
                },
            };
        }
    }
}