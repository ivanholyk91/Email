using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Content.PM;

namespace ParkingPass.Droid.Views
{
    [Activity(Theme = "@style/Theme.AppCompat.Light.NoActionBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class LoginView : MvxAppCompatActivity
    {
        Android.Support.V7.Widget.Toolbar toolbar;
        Android.Graphics.Drawables.Drawable arrowBack = null;
        Android.Support.V7.Widget.AppCompatEditText emailInp;
        Android.Support.V7.Widget.AppCompatEditText passwordInp;
        Android.Support.Design.Widget.TextInputLayout emailHint;
        Android.Support.Design.Widget.TextInputLayout passwordHint;
        Button btnConfirm;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            /*
            CalligraphyConfig.InitDefault(new CalligraphyConfig.Builder()
                .SetDefaultFontPath("Assets/Roboto-Black.ttf")
                .SetFontAttrId(Resource.Attribute.fontPath)
                .DisablePrivateFactoryInjection()
                .Build());*/
            SetContentView(Resource.Layout.LoginView);

            emailInp = FindViewById<Android.Support.V7.Widget.AppCompatEditText>(Resource.Id.logEmail);
            passwordInp = FindViewById<Android.Support.V7.Widget.AppCompatEditText>(Resource.Id.logPassword);

            emailHint = FindViewById<Android.Support.Design.Widget.TextInputLayout>(Resource.Id.emailHint);
            passwordHint = FindViewById<Android.Support.Design.Widget.TextInputLayout>(Resource.Id.passwordHint);
            //emailHint.SetHintTextAppearance(Resource.Style.BlueHintText);
            //passwordHint.SetHintTextAppearance(Resource.Style.BlueHintText);
            
            btnConfirm = FindViewById<Button>(Resource.Id.btnConfirm);

            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.whiteToolbar);
            SetSupportActionBar(toolbar);
            var actionBar = SupportActionBar;
            if(actionBar != null)
            {
                actionBar.SetDisplayHomeAsUpEnabled(true);
                actionBar.SetDisplayShowHomeEnabled(true);
            }
            
            arrowBack = Resources.GetDrawable(Resource.Drawable.ic_arrow_back_black_36dp).Mutate();
            arrowBack.SetColorFilter(Resources.GetColor(Resource.Color.black), Android.Graphics.PorterDuff.Mode.Multiply);
            actionBar.SetHomeAsUpIndicator(arrowBack);
            actionBar.Title = "";
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                this.OnBackPressed();
            }
            return base.OnOptionsItemSelected(item);
        }
        
    }
}