using Kursach.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Kursach
{
    public class LoginStartPageViewModel : BaseViewModel
    {
        public LoginViewModel LoginWindow;

        public RelayCommand OpenLoginPageCommand { get; set; }
        public RelayCommand OpenSignupPageCommand { get; set; }

        public LoginStartPageViewModel()
        {
            LoginWindow = LoginViewModel.Instance;

            OpenLoginPageCommand = new RelayCommand(async () => await LoginWindow.OpenPage(new LoginPage()));
            OpenSignupPageCommand = new RelayCommand(async () => await LoginWindow.OpenPage(new SignupPage()));
        }
        
    }
}
