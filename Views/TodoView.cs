using Android.App;
using Android.OS;

namespace MP140.Views
{
    [Activity(Label = "TodoView")]
    public class TodoView : Activity
    {       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main_view);
            
        }        
    }
}