using AllianceManagementSystem.Wpf.IPresenter.Login_Interface;
using AllianceManagementSystem.Wpf.Views.LoginView;
using EntityFramework.Jwt;
using EntityFramework.Services;
using Notifications.Wpf.Core;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using AllianceManagementSystem.Wpf.Views.LandingPageView;
using Newtonsoft.Json.Linq;
using Azure;
using AllianceManagementSystem.Wpf.ErrorHandler;

namespace AllianceManagementSystem.Wpf.Presenter.Login_Presenter
{
    public class LoginPresenter
    {
        private readonly IUserService _userService;
        private readonly ILoginView _view;

        private readonly UserErrorHandler userErrorHandler;
        private readonly SemaphoreSlim _loginSemaphore = new SemaphoreSlim(1, 1);
        private int _loginAttempts = 0;
        private bool _loggedIn = false;
        //private LoginPage _loginPage;


        public LoginPresenter(ILoginView view, IUserService userService)
        {
            _userService = userService;
            _view = view;
            _view.LoginClicked += OnLoginClicked;

            //_view.SetLoginPage(loginPage);
            userErrorHandler = new UserErrorHandler();
        }

        public async void OnLoginClicked(object sender, RoutedEventArgs e)
        {
            if (!_loginSemaphore.Wait(0) || _loggedIn) // Check if already logged in
            {
                return;
            }

            try
            {
                _view.IsLoginButtonEnabled = false; // Disable the login button

                string username = _view.UsernameInput;
                string password = _view.PasswordInput;

                AuthenticateResponse response = await _userService.Authenticate(new AuthenticateRequest
                {
                    Username = username,
                    Password = password,
                    
                });

                if (response != null)
       
                {
                  
                    

                    _loggedIn = true;  

                    if (_view is LoginPage loginPage)
                    {

                        LandingPage landingPage = new LandingPage(_userService);
                        landingPage.Closed += (s, args) => _loggedIn = false;  // Reset login state on landing page close
                        
                        landingPage.Show();
                 
                        loginPage.Close();
                    }
                }
                else
                {
                    _loginAttempts++;  


                   userErrorHandler.ErrorInputUser();
                }
            }
            finally
            {
                _view.IsLoginButtonEnabled = true; // Enable the login button
                _loginSemaphore.Release(); // Release the semaphore
            }
        }

        public void ResetLoginState()
        {
            _loggedIn = false;
            _loginAttempts = 0;
        }



        
     

    }
}
