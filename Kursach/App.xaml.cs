using Microsoft.IdentityModel.Protocols;
using System;
using System.Configuration;
using System.Linq;
using System.Windows;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //Kursach.Properties.Settings.Default.Reset();//REMOVE IT ON PRODUCTION, LEAVE IT JUST FOR TEST

            int startupWindowOption = Kursach.Properties.Settings.Default.IsLoggedIn;
            //int loggedUserId = Kursach.Properties.Settings.Default.LoggedUserId;
            Console.WriteLine(startupWindowOption.ToString());

            //User loggedUser = UnitOfWork.Users.Get(u => u.Id == loggedUserId).FirstOrDefault();

            if (startupWindowOption == 1)
            {
                Application.Current.StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
            }
            else
            {
                Application.Current.StartupUri = new Uri("Views/LoginWindow.xaml", UriKind.Relative);
            }
            
        }
    }
}
