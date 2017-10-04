using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using Calligraphy;

namespace ParkingPass.Droid.Views
{
    [Activity(Label = "View for MainViewModel", Theme = "@style/Theme.AppCompat.Light.NoActionBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //CalligraphyConfig.InitDefault(new CalligraphyConfig.Builder()

               //.SetDefaultFontPath("fonts/Tahoma.ttf")
               //.SetFontAttrId(Resource.Attribute.fontPath)
               //.AddCustomViewWithSetTypeface(Java.Lang.Class.FromType(typeof(LoginView)))
               // .AddCustomStyle(Java.Lang.Class.FromType(typeof(LoginView)), Resource.Attribute.fontPath)
               // .Build());


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
