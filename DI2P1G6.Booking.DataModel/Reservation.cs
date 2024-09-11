using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI2P1G6.Booking.DataModel
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly HeureDebut { get; set; }
        public TimeOnly HeureFin { get; set; }
        public int EspaceId { get; set; }
        public int TypeId { get; set; }
    }
}
}
