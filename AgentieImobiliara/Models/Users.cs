using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

using AgentieImobiliara.Services;

namespace AgentieImobiliara.Models
{
    public class Users : INotifyPropertyChanged, IUserRepository
    {
        public int UserID { get; set; }
        public string UserType { get; set; } // 'Agent', 'Privat'
        public string Username { get; set; }
        public string PasswordHashed { get; set; }
        public string Email { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string NrTelefon { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime DataCreare { get; set; }

        private readonly AgentieDataContext _context;

        public Users()
        {
            _context = new AgentieDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode

        public bool AutentificareUser(NetworkCredential credential)
        {
            try
            {
                string email = credential.UserName;
                string password = credential.Password;

                var user = _context.Users.FirstOrDefault(u => u.Email == email || u.Username == email);

                if (user == null)
                    return false;

                string hashedPassword = ParolaHashed.HashedPassword(password);

                if (user.PasswordHashed != hashedPassword)
                    return false;

                if (user.Email != email)
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }  

    }
    
}
