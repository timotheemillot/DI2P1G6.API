using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI2P1G6.Booking.DataModel
{
    public class Utilisateur
    {
        public int UtilisateurId { get; set; }
        public string Identifiant { get; set; }
        public string MotDePasse { get; set; }
        public string Email { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public bool Role { get; set; }
    }
}
