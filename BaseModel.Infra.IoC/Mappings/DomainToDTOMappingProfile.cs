using AutoMapper;
using BaseModel.Application.DTOs;
using BaseModel.Domain.Entities;

namespace BaseModel.Infra.Ioc.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
