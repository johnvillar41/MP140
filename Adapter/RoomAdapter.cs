using Android.Views;
using AndroidX.RecyclerView.Widget;
using MP140.Models;
using System.Collections.Generic;

namespace MP140.Adapter
{
    public class RoomAdapter : RecyclerView.Adapter
    {
        private List<RoomModel> _roomModels;

        public RoomAdapter(List<RoomModel> roomModels)
        {
            _roomModels = roomModels;
        }

        public override int ItemCount
        {
            get { return ((List<RoomModel>)_roomModels).Count; }
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