using DI2P1G6.Booking.DataModel;
using DI2P1G6.Booking.Repository.Contract;
using DI2P1G6.Booking.Service.Contract;

namespace DI2P1G6.Booking.Service
{
    public class RessourcesService(IRessourcesRepository ressourcesRepository) : IRessourcesService
    {
        public List<Ressource> SearchAvailableRessources(int? siteId, int? capacite, DateTime? date, TimeSpan? heureDebut, TimeSpan? heureFin)
        {
            return ressourcesRepository.GetAvailableRessources(siteId, capacite, date, heureDebut, heureFin);
        }

        public List<Ressource> GetAll()
        {
            return ressourcesRepository.GetAll();
        }
        public void CreateRessource(Ressource ressource)
        {
            ressourcesRepository.CreateRessource(ressource);
        }

    }
}
