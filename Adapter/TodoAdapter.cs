using Android.Views;
using AndroidX.RecyclerView.Widget;
using MP140.Models;
using System.Collections.Generic;

namespace MP140.Adapter
{
    public class TodoAdapter : RecyclerView.Adapter
    {
        private readonly List<TodoModel> _todoModels;
        public TodoAdapter(List<TodoModel> todoModels)
        {
            _todoModels = todoModels;
        }
        public override int ItemCount 
        { 
            get
            {
                return _todoModels.Count;
            }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            TodoViewHolder viewHolder = holder as TodoViewHolder;
            viewHolder.TodoId.Text = _todoModels[position].Id.ToString();
            viewHolder.TodoTitle.Text = _todoModels[position].Title.ToString();
            viewHolder.TodoDescription.Text = _todoModels[position].Description.ToString();
            viewHolder.TodoStatus.Text = _todoModels[position].Status.ToString();
            viewHolder.DateStarted.Text = _todoModels[position].DateStarted.ToString();
            viewHolder.DateFinished.Text = _todoModels[position].DateFinished.ToString();
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                     Inflate(Resource.Layout.todo_recyclerview, parent, false);
            TodoViewHolder viewHolder = new TodoViewHolder(itemView);
            return viewHolder;
        }
    }
}