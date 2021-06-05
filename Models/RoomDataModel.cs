namespace MP140.Models
{
    public class RoomDataModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public RoomModel Room { get; set; }
        public TodoModel TodoItem { get; set; }
    }
}