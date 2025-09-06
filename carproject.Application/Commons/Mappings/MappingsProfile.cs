using AutoMapper;
using carproject.Application.Dto;
using carproject.Domain.Entities;

namespace carproject.Application.Commons.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<MarcasAutos, MarcasAutosDto>().ReverseMap();
        }
    }
}
