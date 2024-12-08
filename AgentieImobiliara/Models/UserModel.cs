using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using AgentieImobiliara.Services;


namespace AgentieImobiliara.Models
{
    public class UserModel : INotifyPropertyChanged, IUserRepository
    {
        public int UserID { get; set; }
        public string UserType { get; set; } // 'Agent', 'Privat'
        public string Username { get; set; }
        public string PasswordHashed { get; set; }
        public string Email { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string NrTelefon { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime DataCreare { get; set; }


        private readonly AgentieDataContext _context;
        public readonly SessionService _sessionService;
    
        public UserModel(SessionService sessionService)
        {
            _sessionService = sessionService;
            _context = new AgentieDataContext();
        }

        public event PropertyChangedEventHandler PropertyChanged;

       
        //implementare metode

        /// <summary>
        /// Metoda de AUTENTIFICARE
        /// </summary>
        /// <param name="credential"></param>
        /// <returns></returns>
        public bool AutentificareUser(NetworkCredential credential)
        {
            try
            {
                string email = credential.UserName;
                string password = credential.Password;

                var user = _context.Users.FirstOrDefault(u => u.Email == email || u.Username == email);

                if (user == null)
                    return false;

                string hashedPassword = ParolaHashed.HashedPassword(password);

                if (user.PasswordHashed != hashedPassword)
                    return false;

                if (user.Email != email)
                    return false;

                UserModel userModel=new UserModel(_sessionService);
                _sessionService.SetCurrentUser(userModel);

                user.isActive = true;
                _context.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Metoda de INREGISTRARE
        /// </summary>
        public void InregistrareUser()
        {
            try
            {
                var userExist = _context.Users.Any(u => u.Username == Username);
                if (userExist)
                {
                    Console.WriteLine("Utilizatorul există deja.");
                }
              

                if (UserType == "Privat")
                {
                    PrivatModel privatUser = new PrivatModel(_sessionService)
                    {
                        Nume = Nume,
                        Prenume = Prenume,
                        Username = Username,
                        Email = Email,
                        NrTelefon = NrTelefon,
                        PasswordHashed = this.PasswordHashed,
                        IsActive = IsActive,
                        DataCreare = DataCreare,
                        UserType = UserType,
                    };

                    privatUser.InregistrarePrivatUser(privatUser);
                    Console.WriteLine("Inregistrare utilizator Privat reusita!");

                }
                else if (UserType == "Agent")
                {
                    AgentModel agentUser = new AgentModel(_sessionService)
                    {
                        Nume = Nume,
                        Prenume = Prenume,
                        Username = Username,
                        Email = Email,
                        NrTelefon = NrTelefon,
                        PasswordHashed = this.PasswordHashed,
                        IsActive = IsActive,
                        DataCreare = DataCreare,
                        UserType = UserType
                    };

                    agentUser.InregistrareAgentUser(agentUser);
                    Console.WriteLine("Inregistrare utilizator Agent reusita!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la inregistrare User: {ex.Message}");
            }
        }

       public void DeconectareUser()
       {
            try
            { 
                SaveUserData();

                _sessionService.ClearCurrentUser();

                Console.WriteLine("Utilizatorul a fost deconectat cu succes.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la deconectare: {ex.Message}");
            }
        }

        private void SaveUserData()
        {
            try
            {
                if (_sessionService.CurrentUser != null)
                {
                    var user = _context.Users.FirstOrDefault(u => u.UserID == _sessionService.CurrentUser.UserID);
                    if (user != null)
                    {
                        user.isActive = false;
                        _context.SubmitChanges();
                        Console.WriteLine("Datele utilizatorului au fost salvate.");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Eroare la salvarea datelor utilizatorului: {ex.Message}");
            }
        }
    }

}
