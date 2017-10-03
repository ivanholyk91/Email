using MvvmCross.Core.ViewModels;
using ParkingPass.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPass.Core.ViewModels
{
    public class RegisterViewModel : MvxViewModel
    {
        private string _fullName;
        public string FullName {
            get { return _fullName; }
            set { _fullName = value; RaisePropertyChanged(() => FullName); }
        }

        private List<Title> _title = new List<Title>()
        {
            Enums.Title.Manager, Enums.Title.PM
        };
        public List<Title> Title {
            get { return _title; }
            set { _title = value; RaisePropertyChanged(() => Title); }
        }

        private List<Appartament> _appartament = new List<Appartament>()
        {
            Enums.Appartament.Hostel, Enums.Appartament.Hotel
        };
        public List<Appartament> Appartament {
            get { return _appartament; }
            set { _appartament = value; RaisePropertyChanged(() => Appartament); }
        }
    }
}
