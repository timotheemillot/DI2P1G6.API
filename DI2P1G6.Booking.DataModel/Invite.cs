using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI2P1G6.Booking.DataModel
{
    public class Invite
    {
        public int InviteID { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public bool Externe { get; set; }
    }
}
