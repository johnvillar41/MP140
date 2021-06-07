using MP140.Interfaces;
using MP140.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;

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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{Constants.ROOT_URL}addRoom.php?roomName={newRoom.RoomName}&roomDescription={newRoom.RoomDescription}&roomType={newRoom.RoomType}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using StreamReader reader = new StreamReader(response.GetResponseStream());
        }
        public void DeleteRoom(int roomId)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{Constants.ROOT_URL}deleteRoom.php?roomID{roomId}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using StreamReader reader = new StreamReader(response.GetResponseStream());
        }
        public List<RoomModel> FetchAllRooms()
        {
            List<RoomModel> roomModels = new List<RoomModel>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{Constants.ROOT_URL}fetchAllRooms.php");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using StreamReader reader = new StreamReader(response.GetResponseStream());
            var res = reader.ReadToEnd();
            using JsonDocument doc = JsonDocument.Parse(res);
            JsonElement root = doc.RootElement;
            for (int i = 0; i < root.GetArrayLength(); i++)
            {
                RoomModel model = new RoomModel
                {
                    Id = int.Parse(root[i].GetProperty("Room_ID").ToString()),
                    RoomName = root[i].GetProperty("Room_Name").ToString(),
                    RoomDescription = root[i].GetProperty("Room_Description").ToString()                    
                };
                switch (root[i].GetProperty("Room_Type").ToString())
                {
                    case nameof(Constants.RoomType.Academics):
                        model.RoomType = Constants.RoomType.Academics;
                        break;
                    case nameof(Constants.RoomType.Sports):
                        model.RoomType = Constants.RoomType.Sports;
                        break;
                    case nameof(Constants.RoomType.Games):
                        model.RoomType = Constants.RoomType.Games;
                        break;
                    case nameof(Constants.RoomType.Hangouts):
                        model.RoomType = Constants.RoomType.Hangouts;
                        break;
                }
                roomModels.Add(model);
            }
            return roomModels;
        }
    }
}