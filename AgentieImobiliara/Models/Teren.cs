using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public class Teren:Proprietate
    {
        public int TerenID { get; set; }
        public Proprietate Proprietate { get; set; }
        public string TipTeren { get; set; } // 'Intravilan', 'Extravilan'
        public bool Gaz { get; set; }
        public bool Electricitate { get; set; }
        public bool Apa { get; set; }
        public bool Canalizare { get; set; }

        private readonly AgentieDataContext _context;
        public Teren()
        {
            _context = new AgentieDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode
    }
}
