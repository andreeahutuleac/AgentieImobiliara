using AgentieImobiliara.Models;
using AgentieImobiliara.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AgentieImobiliara.ViewModels
{
    public class DeconectareViewModel:BaseViewModel
    {
        private readonly IUserRepository _userRepository;
        public ICommand DeconectareCommand { get; }
        private readonly SessionService _sessionService;

        public DeconectareViewModel()
        {
            _sessionService = new SessionService();
            DeconectareCommand = new CommandViewModel(ExecuteDeconectareCommand);
        }

        public void ExecuteDeconectareCommand(object parameter)
        {
            _sessionService.ClearCurrentUser();
            //deschiderea unei noi ferestre
        }

    }
}
