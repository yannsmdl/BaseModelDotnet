using BaseModel.Application.Commands.City;
using BaseModel.Domain.Interfaces;
using MediatR;
using FluentValidation.Results;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.City
{
    public class CreateCityCommandHandler : CommandHandler, IRequestHandler<CreateCommand, ValidationResult>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IStateRepository _stateRepository;
        public CreateCityCommandHandler
        (
            ICityRepository cityRepository,
            IStateRepository stateRepository
        )
        {
            _cityRepository = cityRepository;
            _stateRepository = stateRepository;
        }

        public async Task<ValidationResult> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var state = await _stateRepository.GetById(request.StateId);
            if (state == null)
            {
                AddError("Estado não existe");
                return ValidationResult;
            }
            var city = new Domain.Entities.City(
                request.Id,
                request.Name,
                request.IbgeId,
                request.StateId
            );
            _cityRepository.Add(city);
            return await Commit(_cityRepository.UnitOfWork);
        }
    }
}
