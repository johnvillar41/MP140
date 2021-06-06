using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using MP140.Interfaces;
using MP140.Models;
using MP140.Presenters;
using MP140.Repositories;
using static Android.Views.View;

namespace MP140.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class LoginView : AppCompatActivity, ILoginView, IOnClickListener
    {
        private LoginPresenter _presenter;

        private EditText et_username, et_password;
        private Button btnLogin, btnRegister;
        private ProgressBar progressBar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_login);
            InitializeViews();
            btnLogin.SetOnClickListener(this);
            btnRegister.SetOnClickListener(this);
        }
        public void OnClick(View v)
        {
            switch (v.Id)
            {
                case Resource.Id.btnLogin:
                    _presenter.OnLogin(et_username.Text.ToString(), et_password.Text.ToString());
                    break;
                case Resource.Id.btnRegister:
                    DisplayRegistrationPopup();
                    break;
            }
        }
        public void DisplayProgressbar()
        {
            RunOnUiThread(() =>
            {
                progressBar.Visibility = Android.Views.ViewStates.Visible;
            });
        }
        public void HideProgressBar()
        {
            RunOnUiThread(() =>
            {
                progressBar.Visibility = Android.Views.ViewStates.Invisible;
            });
        }
        public void DisplayRegistrationPopup()
        {
            Dialog popupDialog = new Dialog(this);
            popupDialog.SetContentView(Resource.Layout.popup_register);
            popupDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
            popupDialog.Show();

            EditText username = popupDialog.FindViewById<EditText>(Resource.Id.txtPopupUsername);
            EditText password = popupDialog.FindViewById<EditText>(Resource.Id.txtPopupPassword);
            EditText realname = popupDialog.FindViewById<EditText>(Resource.Id.txtPopupRealname);
            Button btnRegister = popupDialog.FindViewById<Button>(Resource.Id.btnPopupRegister);
            
            btnRegister.Click += (o, e) =>
            {
                var newUser = new UserModel
                {
                    Username = username.Text.ToString(),
                    Password = password.Text.ToString(),
                    Fullname = realname.Text.ToString()
                };
                _presenter.OnRegister(newUser);
            };
        }
        private void InitializeViews()
        {
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            et_username = FindViewById<EditText>(Resource.Id.et_username);
            et_password = FindViewById<EditText>(Resource.Id.et_password);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            _presenter = new LoginPresenter(this, LoginRepository.SingleInstance);
        }

        public void RedirectToRoomView()
        {
            RunOnUiThread(() =>
            {
                Intent intent = new Intent(this, typeof(RoomView));
                StartActivity(intent);
            });
        }

        public void DisplayErrorMessage()
        {
            RunOnUiThread(() => { Toast.MakeText(this, "Error!", ToastLength.Short).Show(); });
        }
    }
}