using AgentieImobiliara.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieImobiliara.Models
{
    public class AgentModel : UserModel
    {
        public UserModel User { get; set; }
        public int AgentID { get; set; }
        public string NrLicenta { get; set; }
        public string NumeAgentie { get; set; }
        public string AdresaAgentie { get; set; }
        public int AniExperienta { get; set; }

        private readonly AgentieDataContext _context;
        private readonly SessionService _sessionService;
        public AgentModel(SessionService sessionService):base(sessionService)
        {
            _context = new AgentieDataContext();
            _sessionService= sessionService;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode

        public void InregistrareAgentUser(AgentModel agentUser)
        {
            try
            {
                var userExist = _context.Users.SingleOrDefault(u => u.Username == agentUser.Username);
                if (userExist != null)
                {
                    throw new Exception("Utilizatorul există deja!");
                }

                User newUser = new User
                {
                    UserType = "Agent",
                    Username = agentUser.Username,
                    PasswordHashed = agentUser.PasswordHashed,
                    Email = agentUser.Email,
                    Nume = agentUser.Nume,
                    Prenume = agentUser.Prenume,
                    NrTelefon = agentUser.NrTelefon,
                    isActive = agentUser.IsActive,
                    DataCreare = agentUser.DataCreare
                };

                _context.Users.InsertOnSubmit(newUser);
                _context.SubmitChanges();

                UserModel userModel = new UserModel(_sessionService)
                {
                    UserID = newUser.UserID,
                    Username = newUser.Username,
                    Nume = newUser.Nume,
                    Prenume = newUser.Prenume,
                    Email = newUser.Email,
                    NrTelefon = newUser.NrTelefon
                };
                _sessionService.SetCurrentUser(userModel);

                Agent agent = new Agent
                {
                    AgentID = newUser.UserID,
                    NrLicenta=agentUser.NrLicenta,
                    NumeAgentie=agentUser.NumeAgentie,
                    AdresaAgentie=agentUser.AdresaAgentie,
                    AniExperienta=agentUser.AniExperienta,
                };

                _context.Agents.InsertOnSubmit(agent);
                _context.SubmitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la inregistrare Agent: {ex.Message}");
            }
        }

        public AgentModel GetAgentByUsername(string username)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(u => u.Username==username && u.UserType == "Agent");
                if (user != null)
                {
                    var agent= _context.Agents.SingleOrDefault(a => a.AgentID == user.UserID);
                    if(agent!=null)
                    {
                        AgentModel agentModel = new AgentModel(_sessionService)
                        {
                            UserID = user.UserID,
                            Username = user.Username,
                            Nume = user.Nume,
                            Prenume = user.Prenume,
                            Email = user.Email,
                            NrTelefon = user.NrTelefon,
                            NrLicenta = agent.NrLicenta,
                            NumeAgentie = agent.NumeAgentie,
                            AdresaAgentie = agent.AdresaAgentie,
                            AniExperienta = agent.AniExperienta
                        };

                        return agentModel;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la extragerea agentului: {ex.Message}");
                return null;
            }
        }
    }
}
