using Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Repositories;
using System.Threading;
using System.Security.Principal;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Library.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        // Fields 
        private string _email;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible=true;

        private IUserRepository userRepository;

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { 
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Password must be atleast 5 characters.")]
        public SecureString Password { 
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage { 
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible { 
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        // Commands
        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        // Constructor
        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RegisterCommand = new ViewModelCommand(ExecuteRegisterCommand);
        }

        private void ExecuteRegisterCommand(object obj)
        {
            if (!IsEmailUnique(Email))
            {
                ErrorMessage = "This email is already taken!";
            }
            else if (!IsValidEmail(Email))
            {
                ErrorMessage = "Please choose a valid email address!";
            }
            else
            {
                userRepository.Add(new System.Net.NetworkCredential(Email, Password));
                ErrorMessage = "You have succesfully registered!";
            }
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Email) || Email.Length < 3 || Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValisUser = userRepository.AuthenticateUser(new System.Net.NetworkCredential(Email, Password));
            if (isValisUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Email), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Invalid email or password";
            }
        }

        private void ExecuteRecoverPassCommand(string name, string email)
        {
            throw new NotImplementedException();
        }

        private string _connectionString;
        protected SqlConnection GetConnection()
        {
            _connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Library;";

            return new SqlConnection(_connectionString);
        }

        public static bool IsValidEmail(string email)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);

            return emailRegex.IsMatch(email);
        }

        public bool IsEmailUnique(string email)
        {
            using (var connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [Users] WHERE email = @email", connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count == 0;
                }
            }
        }
    }
}
