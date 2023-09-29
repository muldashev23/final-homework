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
        public async Task<ActionResult<IEnumerable<ShoesResponseDto>>> GetShoes()
        {
            var shoes = await _shoesRepository.GetAllShoesAsync();
            return Ok(shoes);
        }

        [HttpGet("{name}")] // GET http://loca....../api/users/{id}
        public async Task<ActionResult<ShoesResponseDto>> GetShoes([FromRoute] string name)
        {
            return await _shoesRepository.GetShoesAsync(name);
        }
    }
}
