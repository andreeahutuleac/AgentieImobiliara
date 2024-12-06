using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public class LegaturaPrivatAgent:INotifyPropertyChanged
    {
        public int LegaturaID { get; set; }
        public Privat Privat { get; set; }
        public Proprietate Proprietate { get; set; }
        public Agent Agent { get; set; }
        public string TipVanzare { get; set; } // 'Direct', 'Prin Agent'

        private readonly AgentieDataContext _context;
        public LegaturaPrivatAgent()
        {
            _context = new AgentieDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode

    }
}
