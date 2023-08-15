using AutoMapper;
using LogixMovie.Application.Dtos;
using LogixMovie.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace LogixMovie.Web
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
