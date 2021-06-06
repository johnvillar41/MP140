using static MP140.Constants;

namespace MP140.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public RoomType RoomType { get; set; }
    }
}