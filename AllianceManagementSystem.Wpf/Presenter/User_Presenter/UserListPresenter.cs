using AllianceManagementSystem.Wpf.Controls.Landing_Page.User_Control;
using AllianceManagementSystem.Wpf.IPresenter.User_Interface;
using AllianceManagementSystem.Wpf.ViewModels;
using Domain.Models.Users;
using EntityFramework.Dto.User_Dto;
using EntityFramework.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Services.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static Microsoft.VisualStudio.Services.Graph.GraphResourceIds;

namespace AllianceManagementSystem.Wpf.Presenter.User_Presenter
{
    public class UserListPresenter 
    {

        private readonly IUnitofwork _unitofwork;
        public ObservableCollection<UserListDto> Users { get; } = new ObservableCollection<UserListDto>();


        public UserListPresenter(IUnitofwork unitofwork)
        { 

          _unitofwork = unitofwork;

        }

        public async Task LoadUsersAsync()
        {
            var users = await _unitofwork.Users.GetAllUsersAsync();

            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(new UserListDto
                {
                    Id = user.Id,
                    FullName = user.Fullname,
                    UserName = user.Username,
                    DateAdded = user.DateAdded.ToString("MM,dd,yyyy"),
                    //IsActive = user.IsActive ? "Yes" : "No"
                });
            }
        }





    }
}
