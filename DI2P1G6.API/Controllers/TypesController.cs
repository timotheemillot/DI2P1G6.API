using DI2P1G6.Booking.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DI2P1G6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController(ITypesService typesService) : ControllerBase
    {
        /// <summary>
        /// Récupère toutes les types disponibles.
        /// GET: api/types
        /// </summary>
        /// <returns>Liste de tous les types</returns>
        [HttpGet("")]
        public List<Booking.DataModel.Type> GetAll()
        {
            var types = typesService.GetAll();
            return types;
        }
    }
}
