using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;

namespace ParkingPass.Droid.Views
{
    [Activity(Label = "View for MainViewModel", Theme = "@style/Theme.AppCompat.Light.NoActionBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);

            var btnSignIn = FindViewById<Button>(Resource.Id.btnSignIn);
            var btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);

            btnSignUp.Click += delegate
            {
                StartActivity(typeof(RegisterView));
            };

            btnSignIn.Click += delegate
            {
                StartActivity(typeof(LoginView));
            };
        }
    }
}
