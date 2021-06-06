using System.Collections.Generic;

namespace MP140.Models
{
    public class RoomDataModel
    {
        public int Id { get; set; }
        public IEnumerable<UserModel> User { get; set; }
        public IEnumerable<RoomModel> Room { get; set; }
        public IEnumerable<TodoModel> TodoItem { get; set; }
    }
}