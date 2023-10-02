using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Backend.Entities;
using Backend.DTOs;
using Backend.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Backend.Data;

public class CartRepository : ICartRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IShoesRepository _shoesRep;

    public CartRepository(DataContext context, IMapper mapper, IShoesRepository shoesRepository)
    {
        _context = context;
        _mapper = mapper;
        _shoesRep = shoesRepository;
    }

    public async Task<SizeDTO> AddToCard(SizeDTO size, AppUser user, Shoes shoes)
    {
        var sizeEntity = new SelectedSize
        {
            SelectedShoesId = size.Id,
            SizeNum = size.SizeNum,
            ShoesIdForSize = shoes.Id
        };

        var cartOfUser = user.Cart;

        if (cartOfUser != null)
        {
            cartOfUser.Shoes.Add(shoes);
            cartOfUser.SelectedSizes.Add(sizeEntity);
        }
        else
        {
            var cart = new Cart
            {
                User = user,
                Shoes = new List<Shoes> { shoes },
                SelectedSizes = new List<SelectedSize> { }
            };
            cart.SelectedSizes.Add(sizeEntity);
            _context.Carts.Add(cart);
        }
        await _context.SaveChangesAsync();
        return size;
    }

    public async Task<CartResponseDTO> ListCart(int id)
    {
        return await _context.Carts
            .Where(x => x.UserId == id)
            .ProjectTo<CartResponseDTO>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
    }
}
