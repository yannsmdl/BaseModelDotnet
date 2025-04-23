using AutoMapper;
using BaseModel.Application.Commands.Categories;
using BaseModel.Application.DTOs;

namespace BaseModel.Infra.Ioc.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<CategoryDTO, CreateCategoryCommand>();
            CreateMap<CategoryDTO, UpdateCategoryCommand>();
        }
    }
}
