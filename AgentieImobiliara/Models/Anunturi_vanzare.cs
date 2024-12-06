using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public class Anunturi_vanzare:INotifyPropertyChanged
    {
        public int AnuntID { get; set; }
        public LegaturaPrivatAgent LegaturaPrivatAgent { get; set; }
        public DateTime DataPublicare { get; set; }
        public DateTime? DataExpirare { get; set; }
        public string StatusAnunt { get; set; } // 'Activ', 'Inactiv', 'Vandut', 'Inchis'


        private readonly AgentieDataContext _context;
        public Anunturi_vanzare()
        {
            _context = new AgentieDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode
    }
}
