using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkingPass.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        public LoginViewModel()
        {
        }

        public override Task Initialize()
        {
            //TODO: Add starting logic here

            return base.Initialize();
        }

        public ICommand GoNext
        {
            get
            {
                return new MvxCommand(() => Next());
            }
        }

        
        public void Next()
        {
            CheckData();
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; RaisePropertyChanged(() => Email); }
        }

        private bool _isEmailValid;

        public bool IsEmailValid
        {
            get
            {
                return _isEmailValid;
            }
            set
            {
                _isEmailValid = value;
                RaisePropertyChanged(() => IsEmailValid);
            }
        }

        private bool _isPasswordValid;

        public bool IsPasswordValid
        {
            get
            {
                return _isPasswordValid;
            }
            set
            {
                _isPasswordValid = value;
                RaisePropertyChanged(() => IsPasswordValid);
            }
        }

        public void CheckData()
        {
            if (!string.IsNullOrWhiteSpace(_email))
                IsEmailValid = true;
            IsEmailValid = false;

        }


        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged(() => Password); }
        }
    }
}
