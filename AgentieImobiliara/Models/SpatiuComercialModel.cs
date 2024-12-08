using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public class SpatiuComercialModel:ProprietateModel
    {
        public int SpatiuID { get; set; }
        public ProprietateModel Proprietate { get; set; }
        public string StadiuConstructie { get; set; }
        public string TipSpatiu { get; set; } // 'Birouri', 'Spatii industriale', 'Spatii comerciale'

        private readonly AgentieDataContext _context;
        public SpatiuComercialModel()
        {
            _context = new AgentieDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode

        public SpatiuComercial ConvertToSpatiuComercial(SpatiuComercialModel model)
        {

            return new SpatiuComercial
            {
                SpatiuID = model.SpatiuID,
                StadiuConstructie = model.StadiuConstructie,
                TipSpatiu = model.TipSpatiu
            };
        }

        public void SaveSpatiuComercial()
        {
            SpatiuComercial spatiu = ConvertToSpatiuComercial(this);
            _context.SpatiuComercials.InsertOnSubmit(spatiu);
            _context.SubmitChanges();
        }
    }
}
