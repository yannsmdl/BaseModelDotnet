using BaseModel.Application.Commands.Client;
using BaseModel.Domain.Interfaces;
using MediatR;
using FluentValidation.Results;
using NetDevPack.Messaging;
using BaseModel.Domain.Account;
using BaseModel.Application.Interfaces;
using BaseModel.Application.DTOs;
using BaseModel.Domain.Enums;

namespace BaseModel.Application.Handlers.Client
{
    public class CreateClientCommandHandler : CommandHandler, IRequestHandler<CreateCommand, ValidationResult>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IProfessionRepository _professionRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IAuthenticate _authenticate;
        private readonly ITenantProvider _tenantProvider;
        private readonly IAddressClientService _addressClientService;
        private readonly IPhoneClientService _phoneClientService;
        private readonly IEmailClientService _emailClientService;
        
        public CreateClientCommandHandler
        (
            IClientRepository clientRepository,
            IAuthenticate authenticate,
            ITenantProvider tenantProvider,
            IAddressClientService addressClientService,
            IPhoneClientService phoneClientService,
            IEmailClientService emailClientService,
            IProfessionRepository professionRepository,
            ICityRepository cityRepository
        )
        {
            _cityRepository = cityRepository;
            _clientRepository = clientRepository;
            _authenticate = authenticate;
            _tenantProvider = tenantProvider;
            _addressClientService = addressClientService;
            _phoneClientService = phoneClientService;
            _emailClientService = emailClientService;
            _professionRepository = professionRepository;
        }

        private async Task<ValidationResult> HandlePF(string userId, CreateCommand request)
        {
            var requiredFields = new (object Field, string ErrorMessage)[]
            {
                (request.ProfessionId, "Informe a profissão"),
                (request.BirthDate, "Informe a data de nascimento"),
                (request.Gender, "Informe o gênero"),
                (request.MatrialStatus, "Informe o estado civil"),
                (request.Identity, "Informe a identidade"),
                (request.DispatcherOrganizationIdentity, "Informe o órgão expedidor"),
                (request.DateIssuanceIdentity, "Informe a data de expedição")
            };

            foreach (var (field, errorMessage) in requiredFields)
            {
                if (field == null)
                {
                    AddError(errorMessage);
                    return ValidationResult;
                }
            }
            var profession = await _professionRepository.GetById(request.ProfessionId ?? Guid.Empty);
            if (profession == null)
            {
                AddError("A profissão não existe");
                return ValidationResult;
            }
            var client = new Domain.Entities.Client(
                request.Id,
                userId,
                request.Name,
                request.Document,
                request.TypeClient,
                request.ProfessionId??Guid.Empty,
                request.BirthDate??DateOnly.MinValue,
                request.Gender??GenderEnum.Male,
                request.MatrialStatus??MatrialStatusEnum.Single,
                request.Identity,
                request.DispatcherOrganizationIdentity,
                request.DateIssuanceIdentity??DateOnly.MinValue
            );
            _clientRepository.Add(client);
            return ValidationResult;
        }

        private async Task<ValidationResult> HandlePJ(string userId, CreateCommand request)
        {
            var requiredFields = new (object Field, string ErrorMessage)[]
            {
                (request.FantasyName, "Informe o nome fantasia"),
                (request.Cnae, "Informe o Cnae"),
                (request.Crea, "Informe o Crea"),
                (request.MunicipalRegistrationNumber, "Informe o registro municipal"),
                (request.StateRegistrationNumber, "Informe o registro estadual")
            };

            foreach (var (field, errorMessage) in requiredFields)
            {
                if (field == null)
                {
                    AddError(errorMessage);
                    return ValidationResult;
                }
            }
            var client = new Domain.Entities.Client(
                request.Id,
                userId,
                request.Name,
                request.Document,
                request.TypeClient,
                request.FantasyName,
                request.Cnae,
                request.Crea,
                request.MunicipalRegistrationNumber,
                request.StateRegistrationNumber
            );
            _clientRepository.Add(client);
            return ValidationResult;
        }

        public async Task<ValidationResult> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            if (request.Password != request.ConfirmPassword)
            {
                AddError("As senhas não conferem");
                return ValidationResult;
            }

            var tenant = _tenantProvider.GetCurrentTenant();
            Guid tenantId = Guid.Parse(tenant.Id.ToString());
            string userId = Guid.NewGuid().ToString();
            
            
            foreach(var addressClient in request.AddressesClient)
            {
                var city = await _cityRepository.GetById(addressClient.CityId);
                if (city == null)
                {
                    AddError($"A Cidade {addressClient.CityId} não existe");
                    return ValidationResult;
                }
                await _addressClientService.Add(new AddressClientDTO(){
                    Id = Guid.NewGuid(),
                    ClientId = request.Id,
                    Street = addressClient.Street,
                    Number = addressClient.Number,
                    Complement = addressClient.Complement,
                    Neighborhood = addressClient.Neighborhood,
                    CityId = addressClient.CityId,
                    ZipCode = addressClient.ZipCode
                });
            }
            foreach(var emailClient in request.EmailsClient)
            {
                await _emailClientService.Add(new EmailClientDTO(){
                    Id = Guid.NewGuid(),
                    ClientId = request.Id,
                    Address = emailClient.Address,
                    Main = false
                });
            }
            foreach(var phoneClient in request.PhonesClient)
            {
                await _phoneClientService.Add(new PhoneClientDTO(){
                    Id = Guid.NewGuid(),
                    ClientId = request.Id,
                    Number = phoneClient.Number,
                    Main = phoneClient.Main
                });
            }

            await _authenticate.RegisterUser(userId, request.EmailMain, request.Password, tenantId);
            if (request.TypeClient == TypeClientEnum.PF)
            {
                var ValidationResultPF = await HandlePF(userId, request);
                if (!ValidationResultPF.IsValid)
                {
                    return ValidationResultPF;
                }
            }
            else
            {
                var ValidationResultPJ = await HandlePJ(userId, request);
                if (!ValidationResultPJ.IsValid)
                {
                    return ValidationResultPJ;
                }
            }
            
            await Commit(_clientRepository.UnitOfWork);
            await _authenticate.Commit();
            return ValidationResult;
        }
    }
}
