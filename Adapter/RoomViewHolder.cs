using Android.Views;
using Android.Widget;
using AndroidX.CardView.Widget;
using AndroidX.RecyclerView.Widget;

namespace MP140.Adapter
{
    public class RoomViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ImageView { get; set; }
        public TextView RoomName { get; set; }
        public TextView RoomDescription { get; set; }
        public CardView RoomCard { get; set; }
        public RoomViewHolder(View itemView) : base(itemView)
        {
            ImageView = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            RoomName = itemView.FindViewById<TextView>(Resource.Id.txtRoomName);
            RoomDescription = itemView.FindViewById<TextView>(Resource.Id.txtRoomDescription);
            RoomCard = itemView.FindViewById<CardView>(Resource.Id.roomCard);
        }
    }
}