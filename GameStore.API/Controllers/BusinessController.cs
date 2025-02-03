using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GameStore.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers
{
    [ApiController]
    [Route("api/business")]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService _businessService;

        public BusinessController(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        [HttpGet("total-price")]
        public async Task<IActionResult> GetTotalGamePrice([FromQuery] IEnumerable<Guid> gameIds)
        {
            var totalPrice = await _businessService.CalculateTotalGamePriceAsync(gameIds);
            return Ok(totalPrice);
        }

        [HttpGet("count-by-genre/{genre}")]
        public async Task<IActionResult> GetGameCountByGenre(string genre)
        {
            var count = await _businessService.CountGamesByGenreAsync(genre);
            return Ok(count);
        }
    }
}
