using Backend.DTOs;
using Backend.Interfaces;
using Backend.Migrations;
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

        [HttpGet]
        public async Task<ActionResult<List<ShoesResponseDto>>> GetAllShoes()
        {
            var shoes = await _shoesRepository.GetAllShoesAsync();
            return Ok(shoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoesResponseDto>> GetShoes([FromRoute] int id)
        {
            var shoes = await _shoesRepository.GetShoesByIdAsync(id);
            if (shoes == null)
                return NotFound();
            return Ok(shoes);
        }

        [HttpGet("gender/{name}")]
        public async Task<ActionResult<List<ShoesResponseDto>>> GetShoesByGender(
            [FromRoute] string name
        )
        {
            var shoes = await _shoesRepository.GetShoesByGender(name);

            return Ok(shoes);
        }

        [HttpGet("brand/{name}")]
        public async Task<ActionResult<List<ShoesResponseDto>>> GetShoesByBrand(
            [FromRoute] string name
        )
        {
            var shoes = await _shoesRepository.GetShoesByBrand(name);

            return Ok(shoes);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> AddShoes([FromBody] ShoesRequestDTO shoes)
        {
            var authenticatedUser = HttpContext.User;
            var userIdClaim = authenticatedUser.Claims.FirstOrDefault(
                claim => claim.Type == "userId"
            );
            if (userIdClaim == null)
            {
                return Unauthorized();
            }
            if (!authenticatedUser.IsInRole("Admin"))
            {
                return Forbid();
            }
            var response = await _shoesRepository.AddShoes(shoes);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> DeleteShoes([FromRoute] int id)
        {
            var authenticatedUser = HttpContext.User;
            var userIdClaim = authenticatedUser.Claims.FirstOrDefault(
                claim => claim.Type == "userId"
            );
            if (userIdClaim == null)
            {
                return Unauthorized();
            }
            if (!authenticatedUser.IsInRole("Admin"))
            {
                return Forbid();
            }
            var response = await _shoesRepository.DeleteShoes(id);
            return Ok();
        }
    }
}
