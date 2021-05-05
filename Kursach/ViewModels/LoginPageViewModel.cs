using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Kursach
{
    public class LoginPageViewModel : BaseViewModel
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

        [Required(ErrorMessage = "Обязательно к заполнению.")]
        [RegularExpression(@"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])([^\s]){8,20}$", ErrorMessage = "Некорректный пароль")]
        [Compare(nameof(Password), ErrorMessage= "Пароли не совпадают.")]
        public string RepeatPassword { get; set; }
        public SolidColorBrush RepeatPasswordBorderBrushColor { get; set; } = new SolidColorBrush(Colors.Transparent);
        public string RepeatPasswordErrorMessage { get; set; }

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
        public RelayCommand SubmitCommand { get; set; }

        #endregion

        public LoginPageViewModel()
        {
            LoginWindow = LoginViewModel.Instance;

            BackPageCommand = new RelayCommand(async () => await LoginWindow.GoBack());

            SubmitCommand = new RelayCommand(() =>
            {
                bool isAllValid = ValidateAllInputs();

                if (isAllValid)
                {
                    Console.WriteLine("Valid");

                    User newUser = CreateNewUser();

                    // if we have no users with that username
                    if (UnitOfWork.Users.Get(u => u.Username == Username).Count == 0)
                    {
                        // add user to database
                        int newUserId = UnitOfWork.Users.CreateWithId(newUser);
                        ErrorMessage = "";

                        Properties.Settings.Default.IsLoggedIn = 1;
                        Properties.Settings.Default.LoggedUserId = newUserId;
                        Properties.Settings.Default.Save();

                        // CREATE MAIN WINDOW WHEN VALID
                        MainWindow mainWindow = new MainWindow();

                        // set active user DO NOT DELETE LET IT BE TO HAVE ACCESS TO USER
                        //MainContentViewModel.Instance.User = newUser;

                        // show main window
                        mainWindow.Show();

                        // close login window
                        LoginViewModel.LoginWindow.Close();
                    }
                    else
                    {
                        ErrorMessage = "Пользователь с таким username уже есть.";
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
                typeof(LoginPageViewModel).GetProperty(warnBorderPropName).SetValue((validationContext.ObjectInstance as LoginPageViewModel), Brushes.Transparent);
                typeof(LoginPageViewModel).GetProperty(warnMessagePropName).SetValue((validationContext.ObjectInstance as LoginPageViewModel), "");

                return true;
            }
            else
            {
                // set border color to warn color and print error message on invalid input

                //fiend property of this type by it's string name and set value on this object's property
                typeof(LoginPageViewModel).GetProperty(warnBorderPropName).SetValue((validationContext.ObjectInstance as LoginPageViewModel),
                    (SolidColorBrush)Application.Current.Resources["DangerRedColorBrush"]);

                typeof(LoginPageViewModel).GetProperty(warnMessagePropName).SetValue((validationContext.ObjectInstance as LoginPageViewModel), 
                    validationResult.ToArray()[0].ErrorMessage);
                
                return false;
            }
        }

        private bool ValidateAllInputs()
        {
            // set flag and validate all necessary properties
            bool isUsernameValid = ValidateUserInput(Username, nameof(Username), "UsernameBorderBrushColor", "UsernameErrorMessage");
            bool isPasswordValid = ValidateUserInput(Password, nameof(Password), "PasswordBorderBrushColor", "PasswordErrorMessage");
            bool isRepeatPasswordValid = ValidateUserInput(RepeatPassword, nameof(RepeatPassword), "RepeatPasswordBorderBrushColor", "RepeatPasswordErrorMessage");

            return isUsernameValid && isPasswordValid && isRepeatPasswordValid;
        }

        private User CreateNewUser()
        {
            User newUser = new User()
            {
                Username = Username,
                Password = Password
            };

            // by default user's nickname equals to user's username
            newUser.UserPublicInfo.Nickname = newUser.Username;

            // generate random color number
            Random rnd = new Random();
            int randAvatarColor = rnd.Next(1, 7);
            string randNum = PathConverters.CheckDigits(randAvatarColor);

            // set random-colored avatar image
            newUser.UserAccountInfo.AvatarImage = ImageConverter.ConvertBitmapSourceToByteArray(new Uri($"pack://application:,,,/Images/Icons/helmet-{randNum}.png"));

            newUser.UserFriendTo = new List<Friendship>();
            newUser.UserFriendWith = new List<Friendship>();

            return newUser;
        }
    }
}
