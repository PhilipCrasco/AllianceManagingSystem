using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace AllianceManagementSystem.Wpf.ErrorHandler
{
    public class UserErrorHandler 
    {

        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.TopRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3),
                maximumNotificationCount: MaximumNotificationCount.FromCount(3));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });





        public void SuccessInputUser()
        {

            if (notifier != null)
            {
                notifier.ShowSuccess("Welcome Niggas");

                Task.Delay(TimeSpan.FromSeconds(5));
                
            }

        }



        public void ErrorInputUser()
        {

            if (notifier != null)
            {
                notifier.ShowError("Username or password are incorrect");

                Task.Delay(TimeSpan.FromSeconds(5));

            }

        }






    }


}
