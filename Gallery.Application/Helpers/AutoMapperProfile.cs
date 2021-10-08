using AutoMapper;
using Gallery.Application.Commands;
using Gallery.Application.Dtos;
using Gallery.Domain;

namespace Gallery.Application.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MovieToGet, ShowDTO>()
                .ForMember(dest => dest.OriginCountry, options => options.MapFrom(src => src.OriginalLanguage));
            CreateMap<TVShowToGet, ShowDTO>()
                .ForMember(dest => dest.Title, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.ReleaseDate, options => options.MapFrom(src => src.FirstAirDate))
                .ForMember(dest => dest.OriginCountry, options => options.MapFrom(src => 
                    src.OriginCountry.Count == 0 ? src.OriginalLanguage : src.OriginCountry[0]));
            CreateMap<MovieDetailsToGet, MovieDetailsDTO>()
                .ForMember(dest => dest.OriginCountry, options => options.MapFrom(src => src.OriginalLanguage));
            CreateMap<TVShowDetailsToGet, TVShowDetailsDTO>()
                .ForMember(dest => dest.Title, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.ReleaseDate, options => options.MapFrom(src => src.FirstAirDate))
                .ForMember(dest => dest.OriginCountry, options => options.MapFrom(src => src.OriginCountry[0]));
            CreateMap<AddMovieCommand, MovieToAdd>();
            CreateMap<AddTVShowCommand, TVShowToAdd>();
            CreateMap<ShowDTO, MovieToAdd>();
            CreateMap<ShowDTO, TVShowToAdd>();
        }
    }
}