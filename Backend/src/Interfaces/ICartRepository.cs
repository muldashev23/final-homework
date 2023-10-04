using Backend.DTOs;
using Backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Interfaces;

public interface ICartRepository
{
    Task<SizeDTO> AddToCard(SizeDTO size, AppUser user, Shoes shoes);
    Task<CartResponseDTO> ListCart(int id);
    Task CheckOut(int id);
}
