using AgentieImobiliara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Services
{
    public class SessionService
    {
        public UserModel CurrentUser { get; set; }

        public void SetCurrentUser(UserModel user)
        {
            CurrentUser = user;
        }

        public void ClearCurrentUser()
        {
            CurrentUser = null;
        }

        public UserModel GetCurrentuser()
        {
            return CurrentUser;
        }
    }
}
