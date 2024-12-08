using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public class CasaModel:ProprietateModel
    {
        public int CasaID { get; set; }
        public ProprietateModel Proprietate { get; set; }
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
        public CasaModel()
        {
            _context = new AgentieDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode
        public Casa ConvertToCasa(CasaModel model)
        {
            return new Casa
            {
                CasaID = model.CasaID,
                StadiuConstructie = model.StadiuConstructie,
                Mobilat_Utilat = model.Mobilat_Utilat,
                NrCamere = model.NrCamere,
                NrBai = model.NrBai,
                NrEtaje = model.NrEtaje,
                Parcare = model.Parcare,
                Garaj = model.Garaj,
                Curte = model.Curte,
                CentralaTermica = model.CentralaTermica,
                Canalizare = model.Canalizare,
                Gradina = model.Gradina,
                Piscina = model.Piscina
            };
        }
        public void SaveCasa()
        {
            Casa casa = ConvertToCasa(this);
            _context.Casas.InsertOnSubmit(casa);
            _context.SubmitChanges();
        }
    }
}
