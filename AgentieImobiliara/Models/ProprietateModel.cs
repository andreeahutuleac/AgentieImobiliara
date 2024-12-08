using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public class ProprietateModel:INotifyPropertyChanged
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
        public ProprietateModel()
        {
            _context = new AgentieDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode
        public Proprietate ConvertToProprietate(ProprietateModel model)
        {
            return new Proprietate
            {
                ProprietateID = model.ProprietateID,
                TipProprietate = model.TipProprietate,
                Inchiriere_Vanzare = model.Inchiriere_Vanzare,
                Denumire = model.Denumire,
                Descriere = model.Descriere,
                Localitate = model.Localitate,
                Judet = model.Judet,
                Pret = model.Pret,
                Suprafata = model.Suprafata
            };
        }

        public void SaveProprietate()
        {
            Proprietate proprietate = ConvertToProprietate(this);
            _context.Proprietates.InsertOnSubmit(proprietate);
            _context.SubmitChanges();

            switch (proprietate.TipProprietate)
            {
                case "Case":
                    if(this is CasaModel casa)
                    {
                        casa.SaveCasa();
                    }
                    break;

                case "Apartamente":
                    if(this is ApartamentModel apartament)
                    {
                        apartament.SaveApartament();
                    }
                    break;

                case "Spatii comerciale":
                    if(this is SpatiuComercialModel spatiuComercial)
                    {
                        spatiuComercial.SaveSpatiuComercial();
                    }
                    break;

                case "Terenuri":
                   if(this is TerenModel teren)
                    {
                        teren.SaveTeren();
                    }
                    break;

                default:
                    throw new Exception("Tipul proprietatii nu este recunoscut!");
            }
        }
    }
}
