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
            CreateMap<State, StateDTO>().ReverseMap();
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<AddressClient, AddressClientDTO>().ReverseMap();
            CreateMap<PhoneClient, PhoneClientDTO>().ReverseMap();
            CreateMap<EmailClient, EmailClientDTO>().ReverseMap();
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Tenant, TenantDTO>().ReverseMap();
            CreateMap<Profession, ProfessionDTO>().ReverseMap();
        }
    }
}
