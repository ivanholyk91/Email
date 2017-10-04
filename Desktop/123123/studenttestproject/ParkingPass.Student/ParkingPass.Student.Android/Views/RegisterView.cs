
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Support.V7.Widget;
using MvvmCross.Binding.Droid.Views;
using Android.Content.PM;
using FR.Ganfra.Materialspinner;
using System.Collections;
using ParkingPass.Core.Enums;

namespace ParkingPass.Droid.Views
{
    [Activity(Theme = "@style/Theme.AppCompat.Light.NoActionBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class RegisterView : MvxAppCompatActivity 
    {
        AppCompatEditText fullName;
        Android.Graphics.Drawables.Drawable arrowBack = null;
        Android.Support.V7.Widget.Toolbar toolbar;
        Android.Support.Design.Widget.TextInputLayout fullNameHint;

        ArrayAdapter adapterTitle;
        ArrayAdapter adapterAppartament;
        ArrayAdapter adapterResident;

        MaterialSpinner titleSpinner;
        MaterialSpinner appartamentSpinner;
        MaterialSpinner residentSpinner;

        protected override void OnCreate(Bundle savedInstance)
        {
            base.OnCreate(savedInstance);
            SetContentView(Resource.Layout.RegisterView);
            
            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.whiteToolbar);
            fullNameHint = FindViewById<Android.Support.Design.Widget.TextInputLayout>(Resource.Id.fullNameHint);
            appartamentSpinner = FindViewById<MaterialSpinner>(Resource.Id.spnAppartament);
            
            //####LOAD ENUMS FROM CORE####
            var enumTitle = Enum.GetValues(typeof(Title));
            var enumAppartament = Enum.GetValues(typeof(Appartament));
            var enumResident = Enum.GetValues(typeof(Resident));
            //############################

            var arrayTitle = enumTitle.Cast<Title>().Select(e => e.ToString()).ToArray();
            var arrayAppartament = enumAppartament.Cast<Appartament>().Select(e => e.ToString()).ToArray();
            var arrayResident = enumResident.Cast<Resident>().Select(e => e.ToString()).ToArray();
            
            //#########ACTION BAR#########
            SetSupportActionBar(toolbar);
            var actionBar = SupportActionBar;
            if (actionBar != null)
            {
                actionBar.SetDefaultDisplayHomeAsUpEnabled(true);
                actionBar.SetDisplayHomeAsUpEnabled(true);
            }
            arrowBack = Resources.GetDrawable(Resource.Drawable.ic_arrow_back_black_36dp).Mutate();
            arrowBack.SetColorFilter(Resources.GetColor(Resource.Color.black), Android.Graphics.PorterDuff.Mode.Multiply);
            actionBar.SetHomeAsUpIndicator(arrowBack);
            actionBar.Title = "";
            //############################
            
            adapterTitle = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem,arrayTitle);
            adapterTitle.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            adapterAppartament = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, arrayAppartament);
            adapterAppartament.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            adapterResident = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, arrayResident);
            adapterResident.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            
            InitSpinnerHintAndFloatingLabel();
            titleSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (TitleSpinner_ItemSelected);
            appartamentSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(TitleSpinner_ItemSelected);

        }

        private void InitSpinnerHintAndFloatingLabel()
        {
            titleSpinner = FindViewById<MaterialSpinner>(Resource.Id.spnTitle);
            appartamentSpinner = FindViewById<MaterialSpinner>(Resource.Id.spnAppartament);
            residentSpinner = FindViewById<MaterialSpinner>(Resource.Id.spnResident);

            titleSpinner.Adapter = adapterTitle;
            appartamentSpinner.Adapter = adapterAppartament;
            residentSpinner.Adapter = adapterResident;

            titleSpinner.SetPaddingSafe(0, 0, 0, 0);
            appartamentSpinner.SetPaddingSafe(0, 0, 0, 0);
            residentSpinner.SetPaddingSafe(0, 0, 0, 0);
        }

        private void TitleSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            MaterialSpinner spinner = (MaterialSpinner)sender;
            int position = e.Position;
            switch (spinner.Id) {
                case Resource.Id.spnTitle:
                    if (!(position < 0))
                        appartamentSpinner.Visibility = ViewStates.Visible;
                    else
                        appartamentSpinner.Visibility = ViewStates.Gone;
                        residentSpinner.Visibility = ViewStates.Gone;
                    break;
                case Resource.Id.spnAppartament:
                    if (!(position < 0))
                        residentSpinner.Visibility = ViewStates.Visible;
                    else
                        residentSpinner.Visibility = ViewStates.Gone;
                    break;
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var inflater = MenuInflater;
            inflater.Inflate(Resource.Menu.menu_text, menu);
            return true; 
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                this.Finish();
            return base.OnOptionsItemSelected(item);
        }
    }
}