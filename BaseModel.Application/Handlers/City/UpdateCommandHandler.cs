using BaseModel.Application.Commands.City;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.City
{
    public class UpdateCityCommandHandler : CommandHandler, IRequestHandler<UpdateCommand, ValidationResult>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IStateRepository _stateRepository;
        public UpdateCityCommandHandler
        (
            ICityRepository cityRepository,
            IStateRepository stateRepository
        )
        {
            _cityRepository = cityRepository;
            _stateRepository = stateRepository;
        }

        public async Task<ValidationResult> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var state = await _stateRepository.GetById(request.StateId);
            if (state == null)
            {
                AddError("Estado não existe");
                return ValidationResult;
            }
            var city = await _cityRepository.GetById(request.Id);
            if (city == null)
            {
                AddError("Cidade não existe");
                return ValidationResult;
            }
            city.Update(request.Name, request.IbgeId, request.StateId);
            
            _cityRepository.Update(city);
            return await Commit(_cityRepository.UnitOfWork);
        }
    }
}
