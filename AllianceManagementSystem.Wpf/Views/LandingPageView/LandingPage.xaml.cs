using AllianceManagementSystem.Wpf.Controls.Landing_Page;
using AllianceManagementSystem.Wpf.ErrorHandler;
using AllianceManagementSystem.Wpf.Presenter.Login_Presenter;
using AllianceManagementSystem.Wpf.Presenter.User_Presenter;
using AllianceManagementSystem.Wpf.Views.LoginView;
using EntityFramework.Services;
using Notifications.Wpf.Core;
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
using System.Windows.Shapes;
using ToastNotifications;

namespace AllianceManagementSystem.Wpf.Views.LandingPageView
{
    /// <summary>
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Window

    {        private LoginPresenter _presenter;
        private readonly IUserService _userService;
            private readonly ReportsControl _reportsControl;
        private readonly IUnitofwork _unitofwork;
        private readonly UserListPresenter userListPresenter;

        public UserListPresenter Presenter { get; set; }


        public LandingPage(IUserService userService)
        {
            InitializeComponent();

            _userService = userService;
            _reportsControl = new ReportsControl();

            

        }



        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Allow the window to be dragged
            DragMove();
        }


        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            GridMenu.Width = new GridLength(39);
        }
        
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
            GridMenu.Width = new GridLength(200);
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
        
            LoginPage loginPage = new LoginPage(_userService);
            loginPage.Show();
            this.Close();
        }

      

        private void ListViewItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (swithControl != null)
            {
                ReportsControl reportsControl = new ReportsControl();
                swithControl.Content = reportsControl;
            }
        }

        private void UserManagement_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (swithControl != null)
            {
               

                UserManagementControl userManagementControl = new UserManagementControl();
                swithControl.Content = userManagementControl;
            }
        }
    }
}
