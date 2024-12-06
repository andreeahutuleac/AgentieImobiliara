using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public class Casa:Proprietate
    {
        public int CasaID { get; set; }
        public Proprietate Proprietate { get; set; }
        public string StadiuConstructie { get; set; }
        public string Mobilat_Utilat { get; set; }
        public int NrCamere { get; set; }
        public int? NrBai { get; set; }
        public int? NrEtaje { get; set; }
        public bool Parcare { get; set; }
        public bool Garaj { get; set; }
        public bool Curte { get; set; }
        public bool CentralaTermica { get; set; }
        public bool Gradina { get; set; }
        public bool Piscina { get; set; }
        public bool Canalizare { get; set; }

        private readonly AgentieDataContext _context;
        public Casa()
        {
            _context = new AgentieDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode
    }
}
