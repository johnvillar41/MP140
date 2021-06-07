using Android.Content;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using MP140.Models;
using MP140.Views;
using System.Collections.Generic;

namespace MP140.Adapter
{
    public class RoomAdapter : RecyclerView.Adapter
    {
        private List<RoomModel> _roomModels;
        private readonly Context _context;

        public RoomAdapter(List<RoomModel> roomModels,Context context)
        {
            _roomModels = roomModels;
            _context = context;
        }        
        public override int ItemCount
        {
            get { return ((List<RoomModel>)_roomModels).Count; }
        }
        public void UpdateData(List<RoomModel> updatedRooms)
        {
            _roomModels = new List<RoomModel>();
            _roomModels.AddRange(updatedRooms);
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RoomViewHolder viewHolder = holder as RoomViewHolder;
            var roomType = _roomModels[position].RoomType;
            switch (roomType)
            {
                case Constants.RoomType.Academics:
                    viewHolder.ImageView.SetImageResource(Resource.Drawable.academics);
                    break;
                case Constants.RoomType.Games:
                    viewHolder.ImageView.SetImageResource(Resource.Drawable.games);
                    break;
                case Constants.RoomType.Hangouts:
                    viewHolder.ImageView.SetImageResource(Resource.Drawable.hangouts);
                    break;
                case Constants.RoomType.Sports:
                    viewHolder.ImageView.SetImageResource(Resource.Drawable.sports);
                    break;
            }
            viewHolder.RoomDescription.Text = _roomModels[position].RoomDescription;
            viewHolder.RoomName.Text = _roomModels[position].RoomName;
            viewHolder.RoomCard.Click += (o, e) =>
            {
                Intent intent = new Intent(_context,typeof(TodoView));
                intent.PutExtra(Constants.ROOM_ID, _roomModels[position].Id.ToString());
                _context.StartActivity(intent);
            };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                     Inflate(Resource.Layout.room_recyclerview, parent, false);
            RoomViewHolder viewHolder = new RoomViewHolder(itemView);
            return viewHolder;
        }
    }
}