using EntityFramework.Dto.User_Dto;
using EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AllianceManagementSystem.Wpf.ViewModels
{
    public class UserListViewModel : INotifyPropertyChanged
    {

        private readonly IUnitofwork _unitofwork;


        public UserListViewModel(IUnitofwork unitofwork)
        {
          _unitofwork = unitofwork;
            Users = new ObservableCollection<UserListDto>();
 
        }

        private ObservableCollection<UserListDto> _users;


        public ObservableCollection<UserListDto> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }


    


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
