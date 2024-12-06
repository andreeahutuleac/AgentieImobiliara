using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public class Proprietate:INotifyPropertyChanged
    {
        public int ProprietateID { get; set; }
        public string TipProprietate { get; set; }
        public string Inchiriere_Vanzare { get; set; }
        public string Denumire { get; set; }
        public string Descriere { get; set; }
        public string Localitate { get; set; }
        public string Judet { get; set; }
        public double Pret { get; set; }
        public decimal Suprafata { get; set; }

        private readonly AgentieDataContext _context;
        public Proprietate()
        {
            _context = new AgentieDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode
    }
}
