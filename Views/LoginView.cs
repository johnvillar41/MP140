using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using MP140.Interfaces;

namespace MP140.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class LoginView : AppCompatActivity, ILoginView
    {

        private EditText et_username, et_password;
        private Button btnLogin, btnRegister;
        private ProgressBar progressBar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_login);
            InitializeViews();
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
            popupDialog.SetContentView(Resource.Layout.popup_room);//Paltan mo tong layout
            popupDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
            popupDialog.Show();
        }
        private void InitializeViews()
        {
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            et_username = FindViewById<EditText>(Resource.Id.et_username);
            et_password = FindViewById<EditText>(Resource.Id.et_password);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);

        }
    }
}