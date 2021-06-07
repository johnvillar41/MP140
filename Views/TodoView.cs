using Android.App;
using Android.Content.PM;
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
using static AndroidX.RecyclerView.Widget.RecyclerView;

namespace MP140.Views
{
    /// <summary>
    ///     This Will Display both the users and the todos inside a specific room
    /// </summary>
    [Activity(Label = "TodoView", LaunchMode =LaunchMode.SingleTask)]
    
    public class TodoView : Activity, ITodoView
    {
        private ProgressBar _progressBar;
        private FloatingActionButton _btnAddTodo;
        private FloatingActionButton _btnDisplayUsers;
        private RecyclerView _recyclerViewTodos;

        private TodoPresenter _presenter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_todoview);
            InitializeViews();

            string id = Intent.GetStringExtra(Constants.ROOM_ID);
            _presenter.OnViewAllTodos(int.Parse(id));
            _btnAddTodo.Click += (o, e) =>
            {
                DisplayPopupAddTodo();
            };
            _btnDisplayUsers.Click += (o, e) =>
            {                
                _presenter.OnViewUsers(int.Parse(id));
            };
        }
        public void DisplayTodosInAGivenRoom(List<TodoModel> todoModels)
        {
            RunOnUiThread(() =>
            {
                _recyclerViewTodos = FindViewById<RecyclerView>(Resource.Id.recyclerViewTodo);
                TodoAdapter adapter = new TodoAdapter(todoModels);
                _recyclerViewTodos.SetAdapter(adapter);
                LayoutManager layoutManager = new LinearLayoutManager(this);
                _recyclerViewTodos.SetLayoutManager(layoutManager);
            });
        }
        public void DisplayUsersInAGivenRoom(List<UserModel> userModels)
        {
            RunOnUiThread(() =>
            {
                Dialog popupDialog = new Dialog(this);
                popupDialog.SetContentView(Resource.Layout.popup_users);
                popupDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
                popupDialog.Show();

                RecyclerView recyclerView = popupDialog.FindViewById<RecyclerView>(Resource.Id.recyclerViewUsers);
                UserAdapter adapter = new UserAdapter(userModels);
                recyclerView.SetAdapter(adapter);
                LayoutManager layoutManager = new LinearLayoutManager(this);
                recyclerView.SetLayoutManager(layoutManager);
            });
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
            _btnAddTodo = FindViewById<FloatingActionButton>(Resource.Id.btnAddTodo);
            _btnDisplayUsers = FindViewById<FloatingActionButton>(Resource.Id.btnDisplayUsers);

            _presenter = new TodoPresenter(this, TodoRepository.SingleInstance);
        }


    }
}