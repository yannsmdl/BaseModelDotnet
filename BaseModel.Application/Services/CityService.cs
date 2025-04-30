using AutoMapper;
using BaseModel.Application.Commands.City;
using BaseModel.Application.DTOs;
using BaseModel.Application.Interfaces;
using BaseModel.Application.Queries.City;
using BaseModel.Application.Shareds;
using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Services
{
    public class CityService : ICityService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CityService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<CityDTO>> GetAll()
        {
            var cityQuery = new GetAllQuery();
            var city = await _mediator.Send(cityQuery);
            return _mapper.Map<IEnumerable<CityDTO>>(city);
        }

        public async Task<CityDTO?> GetById(Guid Id)
        {
            var cityQuery = new GetByIdQuery(Id);
            var city = await _mediator.Send(cityQuery);
            return _mapper.Map<CityDTO>(city);
        }

        public async Task<IEnumerable<CityDTO>> GetByStateId(Guid StateId)
        {
            var cityQuery = new GetByStateIdQuery(StateId);
            var city = await _mediator.Send(cityQuery);
            return _mapper.Map<IEnumerable<CityDTO>>(city);
        }

        public async Task<ValidationResult> Remove(Guid Id)
        {
            var cityRemoveCommand = new RemoveCommand(Id);
            return await _mediator.Send(cityRemoveCommand);
        }

        public async Task<ValidationResult> Update(CityDTO city)
        {
            var cityUpdateCommand = _mapper.Map<UpdateCommand>(city);
            return await _mediator.Send(cityUpdateCommand);
        }

        public async Task<ValidationResultWithData<Guid>> Add(CityDTO city)
        {
            city.Id = Guid.NewGuid();
            var cityCreateCommand = _mapper.Map<CreateCommand>(city);
            var validationResult = await _mediator.Send(cityCreateCommand);
            return new ValidationResultWithData<Guid>(validationResult, city.Id);
        }
    }
}
