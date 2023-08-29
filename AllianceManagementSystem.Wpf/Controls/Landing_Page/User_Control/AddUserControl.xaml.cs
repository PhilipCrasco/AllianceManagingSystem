using AllianceManagementSystem.Wpf.IPresenter.User_Interface;
using AllianceManagementSystem.Wpf.Presenter.User_Presenter;
using AllianceManagementSystem.Wpf.ViewModels;
using EntityFramework.Dto.User_Dto;
using EntityFramework.Repositories.User_Repositories;
using EntityFramework.Services;
using EntityFramework.StoreContext;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Commerce;
using Microsoft.VisualStudio.Services.WebPlatform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Microsoft.VisualStudio.Services.Graph.GraphResourceIds;

namespace AllianceManagementSystem.Wpf.Controls.Landing_Page.User_Control
{
    /// <summary>
    /// Interaction logic for AddUserControl.xaml
    /// </summary>
    public partial class AddUserControl : UserControl
    {


        private readonly Datacontext _context;
        private readonly UserListPresenter _presenter;


        public AddUserControl(Datacontext context)
        {

            _context = context;

            // Initialize UserListPresenter with UserRepository and Storecontext
            _presenter = new UserListPresenter(new Unitofwork(_context));

            // Set the DataContext to the presenter
            DataContext = _presenter;

            // Load users asynchronously
            _presenter.LoadUsersAsync();

        }


    }
}
