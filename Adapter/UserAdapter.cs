using Android.Views;
using AndroidX.RecyclerView.Widget;
using MP140.Models;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;

namespace MP140.Adapter
{
    public class UserAdapter : RecyclerView.Adapter
    {
        private readonly List<UserModel> _userModels;        
        public UserAdapter(List<UserModel> roomModels)
        {
            _userModels = roomModels;            
        }
        public override int ItemCount
        {
            get { return (_userModels).Count; }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            UserViewHolder viewHolder = holder as UserViewHolder;
            viewHolder.Username.Text = _userModels[position].Username.ToString();
            viewHolder.Fullname.Text = _userModels[position].Fullname.ToString();
            viewHolder.UserID.Text = _userModels[position].Id.ToString();            
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                     Inflate(Resource.Layout.user_recyclerview, parent, false);
            UserViewHolder viewHolder = new UserViewHolder(itemView);
            return viewHolder;
        }
    }
}