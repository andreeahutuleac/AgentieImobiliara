using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public class Apartament:Proprietate
    {
        public int ApartamentID { get; set; }
        public Proprietate Proprietate { get; set; }
        public string StadiuConstructie { get; set; }
        public string Compartimentare { get; set; }
        public string Mobilat_Utilat { get; set; }
        public int NrCamere { get; set; }
        public int? NrBai { get; set; }
        public int Etaj { get; set; }
        public bool Parcare { get; set; }
        public bool Garaj { get; set; }
        public bool Curte { get; set; }
        public bool CentralaTermica { get; set; }
        public bool Balcon { get; set; }
        public bool Lift { get; set; }
        public bool Gradina { get; set; }
        public bool Terasa { get; set; }

        private readonly AgentieDataContext _context;
        public Apartament()
        {
            _context = new AgentieDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode
    }
}
