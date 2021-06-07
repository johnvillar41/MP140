using System;
using static MP140.Constants;

namespace MP140.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateStarted { get; set; }
        public Status Status { get; set; }
        public DateTime? DateFinished { get; set; }
    }
}