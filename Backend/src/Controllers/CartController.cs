using System.IdentityModel.Tokens.Jwt;
using Backend.DTOs;
using Backend.Entities;
using Backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Authorize]
public class CartController : BaseApiController
{
    private readonly IShoesRepository _shoesRepository;
    private readonly IUserService _userService;
    private readonly ICartRepository _cartRepository;

    public CartController(
        IShoesRepository shoesRepository,
        IUserService userService,
        ICartRepository cartRepository
    )
    {
        _shoesRepository = shoesRepository;
        _userService = userService;
        _cartRepository = cartRepository;
    }

    [HttpPost("add/{shoesId}")]
    public async Task<ActionResult<SizeDTO>> AddToCard(
        [FromRoute] int shoesId,
        [FromBody] SizeDTO sizeData
    )
    {
        var shoes = await _shoesRepository.GetShoesByIdForCartAsync(shoesId);
        if (shoes == null)
        {
            return NotFound();
        }
        var idClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "userId").Value;
        if (idClaim == null)
        {
            return Unauthorized();
        }

        var user = await _userService.GetUserByIdForCart(int.Parse(idClaim));
        if (user == null)
        {
            return Unauthorized();
        }

        return await _cartRepository.AddToCard(sizeData, user, shoes);
    }

    [HttpGet]
    public async Task<ActionResult<CartResponseDTO>> ListCart()
    {
        var idClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "userId").Value;
        if (idClaim == null)
        {
            return Unauthorized();
        }
        var user = await _userService.GetUserByIdForCart(int.Parse(idClaim));
        if (user == null)
        {
            return Unauthorized();
        }
        if (user.Cart == null)
        {
            return NotFound();
        }
        return await _cartRepository.ListCart(user.Id);
    }
}
