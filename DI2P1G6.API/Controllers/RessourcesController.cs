﻿using DI2P1G6.Booking.Service.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace DI2P1G6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RessourcesController(IRessourcesService ressourcesService) : ControllerBase
    {
        /// <summary>
        /// api/ressources/search
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="capacite"></param>
        /// <param name="date"></param>
        /// <param name="heureDebut"></param>
        /// <param name="heureFin"></param>
        /// <returns></returns>
        [HttpGet("search")]
        public IActionResult SearchRessources([FromQuery] int? siteId, [FromQuery] int? capacite, [FromQuery] DateTime? date, [FromQuery] TimeSpan? heureDebut, [FromQuery] TimeSpan? heureFin)
        {
            var ressources = ressourcesService.SearchAvailableRessources(siteId, capacite, date, heureDebut, heureFin);
            return Ok(ressources);
        }
    }
}
