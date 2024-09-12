using DI2P1G6.Booking.DataModel;
using DI2P1G6.Booking.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DI2P1G6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RessourcesController(IRessourcesService ressourcesService) : ControllerBase
    {
        /// <summary>
        /// Recherche des ressources disponibles en fonction des critères de site, capacité, date et plage horaire.
        /// GET: api/ressources/search
        /// </summary>
        /// <param name="siteId">L'ID du site où chercher des ressources.</param>
        /// <param name="capacite">La capacité de la ressource souhaitée.</param>
        /// <param name="date">La date pour laquelle la ressource est nécessaire.</param>
        /// <param name="heureDebut">Heure de début souhaitée pour la ressource.</param>
        /// <param name="heureFin">Heure de fin souhaitée pour la ressource.</param>
        /// <returns>Liste des ressources disponibles correspondant aux critères.</returns>
        [HttpGet("search")]
        public IActionResult SearchRessources([FromQuery] int? siteId, [FromQuery] int? capacite, [FromQuery] DateTime? date, [FromQuery] TimeSpan? heureDebut, [FromQuery] TimeSpan? heureFin)
        {
            var ressources = ressourcesService.SearchAvailableRessources(siteId, capacite, date, heureDebut, heureFin);
            return Ok(ressources);
        }

        /// <summary>
        /// Récupère toutes les ressources disponibles.
        /// GET: api/ressources/all
        /// </summary>
        /// <returns>Liste de toutes les ressources.</returns>
        [HttpGet("all")]
        public List<Ressourse> GetAll()
        {
            var ressources = ressourcesService.GetAll();
            return ressources;
        }

        /// <summary>
        /// Récupère tous les sites disponibles.
        /// GET: api/ressources/Site
        /// </summary>
        /// <returns>Liste des sites disponibles.</returns>
        [HttpGet("Site")]
        public List<Site> GetSite()
        {
            var sites = ressourcesService.GetSite();
            return sites;
        }

        /// <summary>
        /// Crée une nouvelle ressource.
        /// POST: api/ressources
        /// </summary>
        /// <param name="ressource">L'objet ressource à créer.</param>
        /// <returns>Message indiquant si la création a réussi ou échoué.</returns>
        [HttpPost]
        public IActionResult CreateRessource([FromBody] Ressourse ressource)
        {
            if (ressource == null)
            {
                return BadRequest("Ressource is null.");
            }

            try
            {
                ressourcesService.CreateRessource(ressource);
                return Ok("Ressource created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
