using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public class SpatiuComercial:Proprietate
    {
        public int SpatiuID { get; set; }
        public Proprietate Proprietate { get; set; }
        public string StadiuConstructie { get; set; }
        public string TipSpatiu { get; set; } // 'Birouri', 'Spatii industriale', 'Spatii comerciale'

        private readonly AgentieDataContext _context;
        public SpatiuComercial()
        {
            _context = new AgentieDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode
    }
}
