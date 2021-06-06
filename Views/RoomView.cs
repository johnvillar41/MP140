using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using Google.Android.Material.FloatingActionButton;
using MP140.Adapter;
using MP140.Interfaces;
using MP140.Models;
using MP140.Presenters;
using MP140.Repositories;
using System;
using System.Collections.Generic;

namespace MP140.Views
{
    [Activity(Label = "RoomView")]
    public class RoomView : Activity, IRoomView
    {
        private FloatingActionButton _btnAddRoom;
        private ProgressBar _progressBar;

        private RoomAdapter _adapter;
        private RecyclerView _recyclerView;
        private RoomPresenter _presenter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_room);
            InitializeViews();

            _presenter.LoadRooms();
            _btnAddRoom.Click += DisplayDialogAddRoomForm;

        }
        public void DisplayRooms(List<RoomModel> rooms)
        {
            RunOnUiThread(() =>
            {
                _adapter = new RoomAdapter(rooms, this);
                _recyclerView.SetAdapter(_adapter);
            });
        }
        public void DisplayProgressbar()
        {
            RunOnUiThread(() =>
            {
                _progressBar.Visibility = ViewStates.Visible;
            });
        }

        public void HideProgressBar()
        {
            RunOnUiThread(() =>
            {
                _progressBar.Visibility = ViewStates.Invisible;
            });
        }
        private void DisplayDialogAddRoomForm(object sender, EventArgs e)
        {
            Dialog popupDialog = new Dialog(this);
            popupDialog.SetContentView(Resource.Layout.popup_room);
            popupDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
            popupDialog.Show();

            EditText editTextRoomName = popupDialog.FindViewById<EditText>(Resource.Id.txtPopupRoomName);
            EditText editTextRoomDescription = popupDialog.FindViewById<EditText>(Resource.Id.txtPopupRoomDescription);
            Spinner spinnerRoomType = popupDialog.FindViewById<Spinner>(Resource.Id.spinnerPopupRoomType);
            Button btnAddRoom = popupDialog.FindViewById<Button>(Resource.Id.btnPopupAddRoom);

            var newRoom = new RoomModel
            {
                RoomName = editTextRoomName.Text.ToString(),
                RoomDescription = editTextRoomDescription.Text.ToString()
            };
            var roomText = spinnerRoomType.Selected.ToString();
            switch (roomText)
            {
                case nameof(Constants.RoomType.Academics):
                    newRoom.RoomType = Constants.RoomType.Academics;
                    break;
                case nameof(Constants.RoomType.Games):
                    newRoom.RoomType = Constants.RoomType.Games;
                    break;
                case nameof(Constants.RoomType.Hangouts):
                    newRoom.RoomType = Constants.RoomType.Hangouts;
                    break;
                case nameof(Constants.RoomType.Sports):
                    newRoom.RoomType = Constants.RoomType.Sports;
                    break;
            }
            btnAddRoom.Click += (o, e) => { _presenter.OnAddNewRoom(newRoom); };
        }


        private void InitializeViews()
        {
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.roomRecyclerView);
            _progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            _presenter = new RoomPresenter(this, RoomRepository.SingleInstance);
        }
    }
}