using AgentieImobiliara.Models;
using AgentieImobiliara.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml;


namespace AgentieImobiliara.ViewModels
{
    public class InregistrareViewModel:BaseViewModel
    {
        private readonly IUserRepository _userRepository;
        private string _nume;
        private string _prenume;
        private string _username;
        private SecureString _password;
        private SecureString _confirmedPassword;
        private string _email;
        private string _telefon;
        private string _userType;

        public string Nume
        {
            get { return _nume; }
            set
            {
                _nume = value;
                OnPropertyChanged(nameof(Nume));
            }
        }

        public string Prenume
        {
            get { return _prenume; }
            set
            {
                _prenume = value;
                OnPropertyChanged(nameof(Prenume));
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public SecureString Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public SecureString ConfirmedPassword
        {
            get { return _confirmedPassword; }
            set
            {
                _confirmedPassword = value;
                OnPropertyChanged(nameof(ConfirmedPassword));
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Telefon
        {
            get { return _telefon; }
            set
            {
                _telefon = value;
                OnPropertyChanged(nameof(Telefon));
            }
        }

        public string UserType
        {
            get { return _userType; }
            set
            {
                _userType = value;
                OnPropertyChanged(nameof(UserType));
            }
        }

        public ICommand InregistrareCommand { get; }
        private readonly SessionService _sessionService;

        public InregistrareViewModel()
        {
            _sessionService = new SessionService();
            InregistrareCommand=new CommandViewModel(ExecuteInregistrareCommand, CanExecuteInregistrareCommand);
        }
    
        public bool CanExecuteInregistrareCommand(object obj)
        {
            return !string.IsNullOrWhiteSpace(Nume) && !string.IsNullOrWhiteSpace(Prenume) && !string.IsNullOrWhiteSpace(Username) &&
                                                  !string.IsNullOrWhiteSpace(Email) &&
                                                  Telefon.Length >= 10 &&
                                                  Password != null &&
                                                  Password.Length >= 6 &&
                                                PasswordEqual(Password, ConfirmedPassword);
        }

        public void ExecuteInregistrareCommand(object obj)
        {
            if (Password == null || ConfirmedPassword == null || !PasswordEqual(Password, ConfirmedPassword))
            {
                Console.WriteLine("Parolele nu se potrivesc!");
                return;
            }

            string passwordString = SecureStringToString(Password);
            string confirmedPasswordString = SecureStringToString(ConfirmedPassword);

            try
            {
                UserModel user = new UserModel(_sessionService)
                {
                    Nume = Nume,
                    Prenume = Prenume,
                    Username = Username,
                    Email = Email,
                    NrTelefon = Telefon,
                    PasswordHashed = ParolaHashed.HashedPassword(passwordString),
                    IsActive = true,
                    DataCreare = DateTime.Now,
                    UserType = UserType
                };

                user.InregistrareUser();
                Console.WriteLine("Inregistrare reusita!");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la inregistrare: {ex.Message}");
            }
        }

        private string SecureStringToString(SecureString value)
        {
            if (value == null) return string.Empty;
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(value);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
        private bool PasswordEqual(SecureString pass1, SecureString pass2)
        {
            string password1 = SecureStringToString(pass1);
            string password2 = SecureStringToString(pass2);
            return password1 == password2;
        }

    }
}
