using Android.Views;
using AndroidX.RecyclerView.Widget;
using MP140.Models;
using MP140.Presenters;
using System.Collections.Generic;

namespace MP140.Adapter
{
    public class TodoAdapter : RecyclerView.Adapter
    {
        private readonly List<TodoModel> _todoModels;
        private readonly TodoPresenter _presenter;
        private readonly int _roomID;
        public TodoAdapter(List<TodoModel> todoModels,TodoPresenter presenter,int roomID)
        {
            _todoModels = todoModels;
            _presenter = presenter;
            _roomID = roomID;
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
            if (_todoModels[position].Status.Equals(Constants.Status.Doing))
            {
                viewHolder.ImageStatus.SetImageResource(Resource.Drawable.doing);
                viewHolder.TodoStatus.SetTextColor(Android.Graphics.Color.Blue);                
            }                
            if (_todoModels[position].Status.Equals(Constants.Status.Done))
            {
                viewHolder.ImageStatus.SetImageResource(Resource.Drawable.done);
                viewHolder.TodoStatus.SetTextColor(Android.Graphics.Color.Green);
            }
            viewHolder.CardViewTodo.LongClick += (o, e) =>
            {
                _presenter.OnDeleteTodoItem(_todoModels[position].Id);
                _presenter.OnViewAllTodos(_roomID);
                NotifyItemRangeRemoved(position, ItemCount);
            };
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