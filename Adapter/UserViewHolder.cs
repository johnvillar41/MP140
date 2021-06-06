using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

namespace MP140.Adapter
{
    public class UserViewHolder : RecyclerView.ViewHolder
    {
        public TextView Username { get; set; }
        public TextView Fullname { get; set; }
        public TextView UserID { get; set; }        
        public UserViewHolder(View itemView) : base(itemView)
        {
            Username = itemView.FindViewById<TextView>(Resource.Id.username);
            Fullname = itemView.FindViewById<TextView>(Resource.Id.fullname);
            UserID = itemView.FindViewById<TextView>(Resource.Id.userID);
        }
    }
}