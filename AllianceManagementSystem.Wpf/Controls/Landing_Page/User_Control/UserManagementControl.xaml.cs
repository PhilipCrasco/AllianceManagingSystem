using AllianceManagementSystem.Wpf.Controls.Landing_Page.User_Control;
using AllianceManagementSystem.Wpf.IPresenter.User_Interface;
using AllianceManagementSystem.Wpf.Presenter.User_Presenter;
using EntityFramework.Services;
using EntityFramework.StoreContext;
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
using System.Windows.Threading;

namespace AllianceManagementSystem.Wpf.Controls.Landing_Page
{
    /// <summary>
    /// Interaction logic for UserManagementControl.xaml
    /// </summary>
    public partial class UserManagementControl : UserControl
    {
        private DispatcherTimer timer;
        private UserListPresenter _presenter;
        private readonly IUnitofwork _unitofwork;
        private readonly Datacontext _context;


        public UserManagementControl()
        {
            InitializeComponent();


            // Create and configure the DispatcherTimer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Update every second
            timer.Tick += Timer_Tick;

           
            // Start the timer
            timer.Start();

           
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the TextBlock with the current date and time
            clockTextBlock.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }


        private void AddUser_Click_1(object sender, RoutedEventArgs e)
        {
            AddUserControl adduserControl = new AddUserControl(_context);

            swithControl.Content = adduserControl;
        }

        private void AddRole_Click(object sender, RoutedEventArgs e)
        {
            AddRoleControl addRoleControl = new AddRoleControl();

            swithControl.Content = addRoleControl;
        }
    }
}
