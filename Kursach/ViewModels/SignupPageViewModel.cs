using Kursach.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Kursach
{
    public class SignupPageViewModel : BaseViewModel
    {
        private LoginViewModel LoginWindow;


        #region Public Properties

        public List<ValidationResult> validationResult;
        public ValidationContext validationContext;

        [Required(ErrorMessage = "Обязательно к заполнению.")]
        [RegularExpression(@"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])([^\s]){4,20}$", ErrorMessage = "Некорректное имя пользователя")]
        public string Username { get; set; }
        public SolidColorBrush UsernameBorderBrushColor { get; set; } = Brushes.Transparent;
        public string UsernameErrorMessage { get; set; }

        [Required(ErrorMessage = "Обязательно к заполнению.")]
        [RegularExpression(@"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])([^\s]){8,20}$", ErrorMessage = "Некорректный пароль")]
        public string Password { get; set; }
        public SolidColorBrush PasswordBorderBrushColor { get; set; } = new SolidColorBrush(Colors.Transparent);
        public string PasswordErrorMessage { get; set; }


        /// <summary>
        /// Message to show errors
        /// </summary>
        public string ErrorMessage { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Command to open login start page
        /// </summary>
        public RelayCommand BackPageCommand { get; set; }

        /// <summary>
        /// Command to submit signing up
        /// </summary>
        public RelayCommand SubmitCommand { get; set; }

        #endregion

        public SignupPageViewModel()
        {
            LoginWindow = LoginViewModel.Instance;   

            BackPageCommand = new RelayCommand(async () => await LoginWindow.GoBack());

            SubmitCommand = new RelayCommand(() =>
            {
                // set flag and validate all necessary properties
                bool isUsernameValid = ValidateUserInput(Username, nameof(Username), "UsernameBorderBrushColor", "UsernameErrorMessage");
                bool isPasswordValid = ValidateUserInput(Password, nameof(Password), "PasswordBorderBrushColor", "PasswordErrorMessage");

                if (isUsernameValid && isPasswordValid)
                {
                    User signingUser = UnitOfWork.Users.Get(u => u.Username == Username && u.Password == Password).FirstOrDefault();

                    // if we have no users with that username and password
                    if (signingUser != null)
                    {
                        Console.WriteLine("Valid");

                        // load additional data about user
                        //ExplicitLoaders.LoadAllUserData(signingUser);

                        // clear error message
                        ErrorMessage = "";

                        // add user to database
                        int newUserId = signingUser.Id;

                        Properties.Settings.Default.IsLoggedIn = 1;
                        Properties.Settings.Default.LoggedUserId = newUserId;
                        Properties.Settings.Default.Save();
                        //Properties.Settings.Default.Upgrade();

                        // CREATE MAIN WINDOW WHEN VALID
                        MainWindow mainWindow = new MainWindow();

                        // set active user DO NOT DELETE LET IT BE TO HAVE ACCESS TO USER
                        //MainContentViewModel.Instance.User = signingUser;

                        // show main window
                        mainWindow.Show();

                        // close login window
                        LoginViewModel.LoginWindow.Close();
                    }
                    else
                    {
                        ErrorMessage = "Пользователь не найден.";
                    }
                }
            });
        }


        public bool ValidateUserInput(object property, string propName, string warnBorderPropName, string warnMessagePropName)
        {
            // create validation context object
            validationContext = new ValidationContext(this);

            // list of validation results
            validationResult = new List<ValidationResult>();

            // define property name to validate
            validationContext.MemberName = propName;

            // perform validation
            if (Validator.TryValidateProperty(property, validationContext, validationResult))
            {
                // if validation passed, set border color to transparent and clear error message

                //fiend property of this type by it's string name and set value on this object's property
                typeof(SignupPageViewModel).GetProperty(warnBorderPropName).SetValue((validationContext.ObjectInstance as SignupPageViewModel), Brushes.Transparent);
                typeof(SignupPageViewModel).GetProperty(warnMessagePropName).SetValue((validationContext.ObjectInstance as SignupPageViewModel), "");

                return true;
            }
            else
            {
                // set border color to warn color and print error message on invalid input

                //fiend property of this type by it's string name and set value on this object's property
                typeof(SignupPageViewModel).GetProperty(warnBorderPropName).SetValue((validationContext.ObjectInstance as SignupPageViewModel),
                    (SolidColorBrush)Application.Current.Resources["DangerRedColorBrush"]);

                typeof(SignupPageViewModel).GetProperty(warnMessagePropName).SetValue((validationContext.ObjectInstance as SignupPageViewModel),
                    validationResult.ToArray()[0].ErrorMessage);

                return false;
            }
        }
    }
}
