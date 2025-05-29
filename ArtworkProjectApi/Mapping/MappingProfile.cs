using ArtworkProjectApi.DTOs;
using ArtworkProjectApi.Models;
using AutoMapper;

namespace ArtworkProjectApi.Mapping
{
    public class MappingProfile : Profile
        // AutoMapper profil pro mapování mezi modely a DTO
    {
        public MappingProfile()
        {
            CreateMap<Artwork, ArtworkDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Review, ReviewDto>().ReverseMap();
        }
    }
}
