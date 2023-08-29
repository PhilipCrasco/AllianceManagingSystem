
using AllianceManagementSystem.Wpf.IPresenter.Login_Interface;
using AllianceManagementSystem.Wpf.Presenter.Login_Presenter;
using EntityFramework.Services;
using MaterialDesignThemes.Wpf;
using Notifications.Wpf.Core;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AllianceManagementSystem.Wpf.Views.LoginView
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window, ILoginView 
    {

        private LoginPresenter _presenter;
        private bool loginButtonClicked = false;



        public LoginPage(IUserService userService )
        {
            InitializeComponent();
            _presenter = new LoginPresenter(this, userService);
            loginBtn.Click += loginBtn_Click;
          
        }



        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Allow the window to be dragged
            DragMove();
        }


        public bool isDarkTheme { get; set; }


        private readonly PaletteHelper paletteHelper = new PaletteHelper();

    

        private void changetheme_Click(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();

            if (isDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                isDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }

            else
            {
                isDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }



        public string UsernameInput => txtUserName.Text;
        public string PasswordInput => passwordBox.Password;

    

        public event RoutedEventHandler LoginClicked;
     


        public async void loginBtn_Click(object sender, RoutedEventArgs e)
        {

            if (!loginButtonClicked)
            {

                //loginButtonClicked = true;
                //await Task.Yield();
                //loginBtn.IsEnabled = false;
                //LoginClicked?.Invoke(this, e);
                //await Task.Delay(100);
                //loginButtonClicked = false;
                //loginBtn.IsEnabled = true;

                loginButtonClicked = true;
                loginBtn.IsEnabled = false;
                await Task.Yield();
                LoginClicked?.Invoke(this, e);

                await Task.Delay(200);

                await Dispatcher.InvokeAsync(() =>
                {
                    loginButtonClicked = false;
                    loginBtn.IsEnabled = true;
                });

            }


        }


        public void DisableLoginButton()
        {
            loginButtonClicked = true;
            loginBtn.IsEnabled = false;
        }

        // Method to enable login button
        public void EnableLoginButton()
        {
            loginButtonClicked = false;
            loginBtn.IsEnabled = true;
        }


        public bool IsLoginButtonEnabled 
        {

            set { loginBtn.IsEnabled = value; }
        }

  

        //private LoginPage _loginPage;
        //public void SetLoginPage(LoginPage loginPage)
        //{
        //    _loginPage = loginPage;
        //}
    }
}
