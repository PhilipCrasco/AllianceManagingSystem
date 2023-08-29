using AllianceManagementSystem.Wpf.Views.LoginView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AllianceManagementSystem.Wpf.IPresenter.Login_Interface
{
    public interface ILoginView
    {
        string UsernameInput { get; }
        string PasswordInput { get; }

        event RoutedEventHandler LoginClicked;

        //void SetLoginPage(LoginPage loginPage);
        bool IsLoginButtonEnabled { set; }


    }
}
