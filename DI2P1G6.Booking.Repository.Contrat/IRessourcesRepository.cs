using DI2P1G6.Booking.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI2P1G6.Booking.Repository.Contract
{
    public interface IRessourcesRepository
    {
        List<Ressourse> GetAvailableRessources(int? siteId, int? capacite, DateTime? date, TimeSpan? heureDebut, TimeSpan? heureFin);
        
    }
}
