using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public class Anunturi_vanzareModel:INotifyPropertyChanged
    {
        public int AnuntID { get; set; }
        public LegaturaPrivatAgentModel LegaturaPrivatAgent { get; set; }
        public DateTime DataPublicare { get; set; }
        public DateTime? DataExpirare { get; set; }
        public string StatusAnunt { get; set; } // 'Activ', 'Inactiv', 'Vandut', 'Inchis'


        private readonly AgentieDataContext _context;
        public Anunturi_vanzareModel()
        {
            _context = new AgentieDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode
     
    }
}
