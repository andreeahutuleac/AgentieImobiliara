using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public class Anunturi_vizualizate:INotifyPropertyChanged
    {
        public int VizualizareID { get; set; }
        public Privat Privat { get; set; }  //doar privatul isi poate vedea anunturile
        public Anunturi_vanzare Anunturi_vanzare { get; set; }
        public DateTime DataVizualizare { get; set; }

        private readonly AgentieDataContext _context;
        public Anunturi_vizualizate()
        {
            _context = new AgentieDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode
    }
}
