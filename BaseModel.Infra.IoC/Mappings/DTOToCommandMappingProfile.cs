using AutoMapper;
using BaseModel.Application.Commands.Categories;
using BaseModel.Application.Commands.State;
using BaseModel.Application.DTOs;
using BaseModel.Domain.Entities;

namespace BaseModel.Infra.Ioc.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<CategoryDTO, CreateCategoryCommand>();
            CreateMap<CategoryDTO, UpdateCategoryCommand>();

            CreateMap<StateDTO, CreateStateCommand>();
            CreateMap<StateDTO, UpdateStateCommand>();

            CreateMap<CityDTO, Application.Commands.City.CreateCommand>();
            CreateMap<CityDTO, Application.Commands.City.UpdateCommand>();

            CreateMap<AddressClientDTO, Application.Commands.AddressClient.UpdateCommand>();
            CreateMap<PhoneClientDTO, Application.Commands.PhoneClient.UpdateCommand>();
            CreateMap<EmailClientDTO, Application.Commands.EmailClient.UpdateCommand>();

            CreateMap<ClientDTO, Application.Commands.Client.CreateCommand>();
            CreateMap<ClientDTO, Application.Commands.Client.UpdateCommand>();
            
            CreateMap<TenantDTO, Application.Commands.Tenant.CreateCommand>();
            CreateMap<TenantDTO, Application.Commands.Tenant.UpdateCommand>();

            CreateMap<ProfessionDTO, Application.Commands.Profession.CreateCommand>();
            CreateMap<ProfessionDTO, Application.Commands.Profession.UpdateCommand>();

        }
    }
}
