using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public interface IUserRepository
    {
       bool AutentificareUser(NetworkCredential credential);
       //void InregistrarePrivatUser(Users user);
        //void InregistrareAgentUser(Users user);
       // void UpdateUser(Users user);
        //void Stergere(int id);
        //Users GetUserById(int id);
        //Users GetUserByUsername(string username);

        //ObservableCollection<Users> GetAllUsers();
    }
}
