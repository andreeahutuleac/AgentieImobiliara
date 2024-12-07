using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public class Privat : Users
    {
        public Users User { get; set; }
        public int PrivatID { get; set; }
        public string UserPrivatType { get; set; } // 'Cumparator', 'Vanzator'


        private readonly AgentieDataContext _context;
        public Privat()
        {
            _context = new AgentieDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode

        public void InregistrarePrivatUser(Users user)
        {
            try
            {


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la inregistrare Privat: {ex.Message}");
            }
        }
    }
}
