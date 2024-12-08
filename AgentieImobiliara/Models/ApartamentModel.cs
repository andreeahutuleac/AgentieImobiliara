using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public class ApartamentModel:ProprietateModel
    {
        public int ApartamentID { get; set; }
        public ProprietateModel Proprietate { get; set; }
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
        public ApartamentModel()
        {
            _context = new AgentieDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode
        public Apartament ConvertToApartament(ApartamentModel model)
        {
            return new Apartament
            {
                ApartamentID = model.ApartamentID,
                StadiuConstructie = model.StadiuConstructie,
                Compartimentare = model.Compartimentare,
                Mobilat_Utilat = model.Mobilat_Utilat,
                NrCamere = model.NrCamere,
                NrBai = model.NrBai,
                Etaj = model.Etaj,
                Parcare = model.Parcare,
                Garaj = model.Garaj,
                Curte = model.Curte,
                CentralaTermica = model.CentralaTermica,
                Balcon = model.Balcon,
                Lift = model.Lift,
                Gradina = model.Gradina,
                Terasa = model.Terasa
            };
        }
        public void SaveApartament()
        {
            Apartament apartament = ConvertToApartament(this);
            _context.Apartaments.InsertOnSubmit(apartament);
            _context.SubmitChanges();
        }
    }
}
