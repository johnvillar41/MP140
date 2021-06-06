using Android.App;
using Android.OS;
using Android.Views;
using AndroidX.CardView.Widget;
using AndroidX.RecyclerView.Widget;
using MP140.Adapter;
using MP140.Interfaces;
using MP140.Models;
using System.Collections.Generic;
using static Android.Views.View;

namespace MP140.Views
{
    [Activity(Label = "RoomView")]
    public class RoomView : Activity, IRoomView
    {
        private RoomAdapter _adapter;
        private RecyclerView _recyclerView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_room);
            InitializeViews();          
        }        
        public void DisplayRooms(List<RoomModel> rooms)
        {
            RunOnUiThread(() =>
            {
                _adapter = new RoomAdapter(rooms);
                _recyclerView.SetAdapter(_adapter);
            });            
        }
        private void InitializeViews()
        {
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.roomRecyclerView);           
        }        
    }
}