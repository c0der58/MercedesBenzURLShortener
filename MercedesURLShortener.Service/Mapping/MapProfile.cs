using AutoMapper;
using MercedesURLShortener.Core.DTOs;
using MercedesURLShortener.Core.Models;

namespace MercedesURLShortener.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UrlModel, UrlDto>().ReverseMap();
        }
    }
}
