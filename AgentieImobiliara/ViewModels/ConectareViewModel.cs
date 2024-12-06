using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Windows.Input;
using System.IO.Packaging;

namespace AgentieImobiliara.ViewModels
{
    public class ConectareViewModel:BaseViewModel
    {
        private string _email;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        public string Email
        {
            get { return _email; }
            set
            { 
                _email = value;
                OnPropertyChanged(nameof(Email));
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
        public string ErrorMessage 
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible 
        {
            get { return _isViewVisible; }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public ICommand ConectareCommand { get; }
        public ICommand ShowPasswordCommand { get; }

        public ConectareViewModel()
        {
            ConectareCommand = new CommandViewModel(ExecuteConectareCommand, CanExecuteConectareCommand);
        }

        private bool CanExecuteConectareCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Email) || Email.Length < 3 || Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }

        private void ExecuteConectareCommand(object obj)
        {
           throw new NotImplementedException();
        }
    }
}
