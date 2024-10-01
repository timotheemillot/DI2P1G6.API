using DI2P1G6.Booking.DataModel;
using DI2P1G6.Booking.Service;
using DI2P1G6.Booking.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DI2P1G6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SitesController(ISitesService sitesService) : ControllerBase
    {
        /// <summary>
        /// Récupère toutes les sites disponibles.
        /// GET: api/sites
        /// </summary>
        /// <returns>Liste de tous les sites</returns>
        [HttpGet("")]
        public List<Site> GetAll()
        {
            var sites = sitesService.GetAll();
            return sites;
        }
    }
}
