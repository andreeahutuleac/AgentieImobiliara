using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public class Users:INotifyPropertyChanged
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

        
    }
}
