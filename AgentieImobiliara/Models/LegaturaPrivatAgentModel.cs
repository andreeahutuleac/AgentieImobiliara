using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public class LegaturaPrivatAgentModel:INotifyPropertyChanged
    {
        public int LegaturaID { get; set; }
        public PrivatModel Privat { get; set; }
        public ProprietateModel Proprietate { get; set; }
        public AgentModel Agent { get; set; }
        public string TipVanzare { get; set; } // 'Direct', 'Prin Agent'

        private readonly AgentieDataContext _context;
        public LegaturaPrivatAgentModel()
        {
            _context = new AgentieDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode

    }
}
