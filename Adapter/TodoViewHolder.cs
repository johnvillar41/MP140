using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

namespace MP140.Adapter
{
    public class TodoViewHolder : RecyclerView.ViewHolder
    {
        public TextView TodoId { get; set; }
        public TextView TodoTitle { get; set; }
        public TextView TodoDescription { get; set; }
        public TextView TodoStatus { get; set; }
        public TextView DateStarted { get; set; }
        public TextView DateFinished { get; set; }
        public ImageView ImageStatus { get; set; }
        public TodoViewHolder(View itemView) : base(itemView)
        {
            TodoId = itemView.FindViewById<TextView>(Resource.Id.todoId);
            TodoTitle = itemView.FindViewById<TextView>(Resource.Id.todoTitle);
            TodoDescription = itemView.FindViewById<TextView>(Resource.Id.todoDescription);
            TodoStatus = itemView.FindViewById<TextView>(Resource.Id.todoStatus);
            DateStarted = itemView.FindViewById<TextView>(Resource.Id.todoDateStart);
            DateFinished = itemView.FindViewById<TextView>(Resource.Id.todoDateEnd);
            ImageStatus = itemView.FindViewById<ImageView>(Resource.Id.imageStatus);
        }
    }
}