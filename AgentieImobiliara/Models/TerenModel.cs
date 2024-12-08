using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public class TerenModel:ProprietateModel
    {
        public int TerenID { get; set; }
        public ProprietateModel Proprietate { get; set; }
        public string TipTeren { get; set; } // 'Intravilan', 'Extravilan'
        public bool Gaz { get; set; }
        public bool Electricitate { get; set; }
        public bool Apa { get; set; }
        public bool Canalizare { get; set; }

        private readonly AgentieDataContext _context;
        public TerenModel()
        {
            _context = new AgentieDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode

        public Teren ConvertToTeren(TerenModel model)
        {
            return new Teren
            {
                TerenID = model.TerenID,
                TipTeren = model.TipTeren,
                Gaz=model.Gaz,
                Electricitate=model.Electricitate,
                Apa=model.Apa,
                Canalizare=model.Canalizare
            };
        }

        public void SaveTeren()
        {
            Teren teren = ConvertToTeren(this);
            _context.Terens.InsertOnSubmit(teren);
            _context.SubmitChanges();
        }
    }
}
