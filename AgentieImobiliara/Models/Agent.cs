using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public class Agent : Users
    {
        public Users User { get; set; }
        public int AgentID { get; set; }
        public string NrLicenta { get; set; }
        public string NumeAgentie { get; set; }
        public string AdresaAgentie { get; set; }
        public int AniExperienta { get; set; }

        private readonly AgentieDataContext _context;
        public Agent()
        {
            _context = new AgentieDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode
    }
}
