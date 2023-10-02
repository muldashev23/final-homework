using Backend.DTOs;
using Backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class ShoesController : BaseApiController
    {
        private readonly IShoesRepository _shoesRepository;

        public ShoesController(IShoesRepository shoesRepository)
        {
            _shoesRepository = shoesRepository;
        }

        [HttpGet] // GET http://loca....../api/users
        public async Task<ActionResult<IEnumerable<ShoesResponseDto>>> GetAllShoes()
        {
            var shoes = await _shoesRepository.GetAllShoesAsync();
            return Ok(shoes);
        }

        [HttpGet("{id}")] // GET http://loca....../api/users/{id}
        public async Task<ActionResult<ShoesResponseDto>> GetShoes([FromRoute] int id)
        {
            var shoes = await _shoesRepository.GetShoesByIdAsync(id);
            if (shoes == null)
                return NotFound();
            return Ok(shoes);
        }

        [HttpGet("shoo/{id}")]
        public async Task<ActionResult<ShoesResponseDto>> GetSho([FromRoute] int id)
        {
            var shoes = await _shoesRepository.GetShoo(id);
            if (shoes == null)
                return NotFound();
            return Ok(shoes);
        }
    }
}
