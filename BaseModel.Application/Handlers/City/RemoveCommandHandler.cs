using BaseModel.Application.Commands.City;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.City
{
    public class RemoveCityCommandHandler : CommandHandler, IRequestHandler<RemoveCommand, ValidationResult>
    {
        private readonly ICityRepository _cityRepository;
        public RemoveCityCommandHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<ValidationResult> Handle(RemoveCommand request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetById(request.Id);
            if (city == null)
            {
                AddError("Cidade não existe");
                return ValidationResult;
            }
            _cityRepository.Remove(city);
            return await Commit(_cityRepository.UnitOfWork);
        }
    }
}
