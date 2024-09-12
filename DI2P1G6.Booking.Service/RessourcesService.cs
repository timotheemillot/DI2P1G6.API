using DI2P1G6.Booking.DataModel;
using DI2P1G6.Booking.Repository.Contract;
using DI2P1G6.Booking.Service.Contract;

namespace DI2P1G6.Booking.Service
{
    public class RessourcesService(IRessourcesRepository ressourcesRepository) : IRessourcesService
    {
        public List<Ressourse> SearchAvailableRessources(int? siteId, int? capacite, DateTime? date, TimeSpan? heureDebut, TimeSpan? heureFin)
        {
            return ressourcesRepository.GetAvailableRessources(siteId, capacite, date, heureDebut, heureFin);
        }

        public List<Ressourse> GetAll()
        {
            return ressourcesRepository.GetAll();
        }
        public List<Site> GetSite()
        {
            return ressourcesRepository.GetSite();
        }
        public void CreateRessource(Ressourse ressource)
        {
            ressourcesRepository.CreateRessource(ressource);
        }

    }
}
