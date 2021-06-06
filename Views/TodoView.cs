using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Google.Android.Material.FloatingActionButton;
using MP140.Interfaces;
using MP140.Models;
using MP140.Presenters;
using MP140.Repositories;
using System;

namespace MP140.Views
{
    [Activity(Label = "TodoView")]
    public class TodoView : Activity, ITodoView
    {
        private ProgressBar _progressBar;
        private FloatingActionButton _btnAddRoom;

        private TodoPresenter _presenter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_todoview);
            InitializeViews();
            _btnAddRoom.Click += (o, e) =>
            {
                DisplayPopupAddTodo();
            };
        }      
        public void DisplayProgressBar()
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
        private void DisplayPopupAddTodo()
        {
            Dialog popupDialog = new Dialog(this);
            popupDialog.SetContentView(Resource.Layout.popup_todo);
            popupDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
            popupDialog.Show();

            EditText title = popupDialog.FindViewById<EditText>(Resource.Id.txtPopupTitle);
            EditText description = popupDialog.FindViewById<EditText>(Resource.Id.txtPopupDescription);
            Button btnAddTodo = popupDialog.FindViewById<Button>(Resource.Id.btnAddTodo);

            var todoItem = new TodoModel
            {
                Title = title.Text.ToString(),
                Description = description.Text.ToString(),
                DateStarted = DateTime.Now,
                Status = Constants.Status.Doing
            };
            btnAddTodo.Click += (o, e) =>
            {
                _presenter.OnAddTodoItem(todoItem);
            };
        }
        private void InitializeViews()
        {
            _progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            _btnAddRoom = FindViewById<FloatingActionButton>(Resource.Id.btnAddRoom);

            _presenter = new TodoPresenter(this, TodoRepository.SingleInstance);
        }
    }
}