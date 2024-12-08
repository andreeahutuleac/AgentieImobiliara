using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using AgentieImobiliara.Services;

namespace AgentieImobiliara.Models
{
    public class PrivatModel : UserModel
    {
        public UserModel User { get; set; }
        public int PrivatID { get; set; }
       // public string UserPrivatType { get; set; } // 'Cumparator', 'Vanzator'


        private readonly AgentieDataContext _context;
        private readonly SessionService _sessionService;
        public PrivatModel(SessionService sessionService):base(sessionService)
        {
            _context = new AgentieDataContext();
            _sessionService = sessionService;
        }

       // public event PropertyChangedEventHandler PropertyChanged;

        //implementare metode

        public void InregistrarePrivatUser(PrivatModel privatUser)
        {
            try
            {
                var userExist = _context.Users.SingleOrDefault(u =>u.Username == privatUser.Username);
                if (userExist != null)
                {
                    throw new Exception("Utilizatorul există deja!");
                }

                User newUser = new User
                {
                    UserType = "Privat",
                    Username = privatUser.Username,
                    PasswordHashed = privatUser.PasswordHashed,
                    Email = privatUser.Email,
                    Nume = privatUser.Nume,
                    Prenume = privatUser.Prenume,
                    NrTelefon=privatUser.NrTelefon,
                    isActive = privatUser.IsActive,
                    DataCreare = privatUser.DataCreare
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

                Privat privat = new Privat
                {
                    PrivatID = newUser.UserID
                };

                _context.Privats.InsertOnSubmit(privat);
                _context.SubmitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la inregistrare Privat: {ex.Message}");
            }
        }

        public PrivatModel GetPrivatByUsername(string username)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(u => u.Username == username && u.UserType == "Privat");
                if (user != null)
                {
                    PrivatModel privat = new PrivatModel(_sessionService)
                    {
                        PrivatID = user.UserID,
                        Username = user.Username,
                        Prenume = user.Prenume,
                        Nume = user.NrTelefon,
                        Email = user.Email,
                        NrTelefon = user.NrTelefon
                    };
                    return privat;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Eroare la extragerea privatului: {ex.Message}");
                return null;
            }
        }
    }
}
