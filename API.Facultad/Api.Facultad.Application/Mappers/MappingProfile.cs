using Api.Facultad.Application.Features.Facultad.Command.CreateFacultad;
using Api.Facultad.Domain.Entities;
using AutoMapper;

namespace Api.Facultad.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateFacultadCommand, Facultade>()
                .ForMember(d => d.Nombre, opt => opt.MapFrom(src =>src.Nombre))
                .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.UserId))
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(d => d.CreatedFrom, opt => opt.MapFrom(src => "create facultad")); 
        }
    }
}
