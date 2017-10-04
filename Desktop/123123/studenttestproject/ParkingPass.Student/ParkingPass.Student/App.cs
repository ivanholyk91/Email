using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using ParkingPass.Student.Configuration.Startup;
using ParkingPass.Student.Infrastructure.DAL;
using ParkingPass.Student.Infrastructure.DAL.Interfaces;
using ParkingPass.Student.Infrastructure.REST;
using ParkingPass.Student.Infrastructure.REST.Interfaces;

namespace ParkingPass.Student
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            ConfigureIoC();

            Mvx.ConstructAndRegisterSingleton<IMvxAppStart, MvxAppExtendedStart>();
            var appStart = Mvx.Resolve<IMvxAppStart>();
            // register the appstart object:
            RegisterAppStart(appStart);
        }

        private void ConfigureIoC()
        {
            //Mvx.RegisterType<IAuthenticationService, AuthenticationService>();
            Mvx.LazyConstructAndRegisterSingleton<IDataLayer, DataLayer>();
            Mvx.LazyConstructAndRegisterSingleton<IHttpService, HttpService>();
        }
    }
}
