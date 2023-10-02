using Backend.DTOs;
using Backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Interfaces;

public interface ICartRepository
{
    public Task<SizeDTO> AddToCard(SizeDTO size, AppUser user, Shoes shoes);
    public Task<CartResponseDTO> ListCart(int id);
}
