using AutoMapper;
using Domain.Models;
using Gallery.Shared.Dtos;

namespace Gallery.Application.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Movie, ShowDTO>()
                .ForMember(dest => dest.OriginCountry, options => options.MapFrom(src => src.OriginalLanguage));
            CreateMap<TVShow, ShowDTO>()
                .ForMember(dest => dest.Title, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.ReleaseDate, options => options.MapFrom(src => src.FirstAirDate))
                .ForMember(dest => dest.OriginCountry, options => options.MapFrom(src => 
                    src.OriginCountry.Count == 0 ? src.OriginalLanguage : src.OriginCountry[0]));
            CreateMap<MovieDetails, MovieDetailsDTO>()
                .ForMember(dest => dest.OriginCountry, options => options.MapFrom(src => src.OriginalLanguage));
            CreateMap<TVShowDetails, TVShowDetailsDTO>()
                .ForMember(dest => dest.Title, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.ReleaseDate, options => options.MapFrom(src => src.FirstAirDate))
                .ForMember(dest => dest.OriginCountry, options => options.MapFrom(src => src.OriginCountry[0]));
        }
    }
}