using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPass.Student.Configuration.Startup
{
    public class MvxAppExtendedStart : IMvxAppStart
    {
        //private readonly IAuthenticationService _authenticationService;
        //private readonly IMvxNavigationService _navigationService;

        // Initialize authentication service and navigation service using constructor dependency injection:
        //public MvxAppExtendedStart(IAuthenticationService authenticationService, IMvxNavigationService navigationService)
        //{
        //    _authenticationService = authenticationService;
        //    _navigationService = navigationService;
        //}

        public void Start(object hint = null)
        {
            // If user is not authenticated display LoginViewModel:
            //if (!_authenticationService.IsLoggedIn())
            //_navigationService.Navigate<LoginViewModel>();
            // else display HomeViewModel:
            //else
            //_navigationService.Navigate<HomeViewModel>();
        }
    }
}
