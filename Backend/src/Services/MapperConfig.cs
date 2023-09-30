﻿using AutoMapper;
using Backend.Entities;
using Backend.DTOs;

namespace Backend.Services
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ShoesRequestDTO, Shoes>();
            CreateMap<ShoesResponseDto, Shoes>()
                .ReverseMap()
                .ForMember(
                    dest => dest.PhotoUrl,
                    opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url)
                );
            CreateMap<Photo, PhotoDTO>().ReverseMap();
        }
    }
}