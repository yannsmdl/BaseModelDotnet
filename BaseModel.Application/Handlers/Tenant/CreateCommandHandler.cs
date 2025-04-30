using BaseModel.Application.Commands.Tenant;
using BaseModel.Domain.Interfaces;
using MediatR;
using FluentValidation.Results;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.Tenant
{
    public class CreateTenantCommandHandler : CommandHandler, IRequestHandler<CreateCommand, ValidationResult>
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly ITenantDbContextRouteFactory _tenantDbContextRouteFactory;
        private readonly IConnectionStringValidator _connectionStringValidator;
        public CreateTenantCommandHandler
        (
            ITenantRepository tenantRepository,
            ITenantDbContextRouteFactory tenantDbContextRouteFactory,
            IConnectionStringValidator connectionStringValidator
        )
        {
            _tenantRepository = tenantRepository;
            _connectionStringValidator = connectionStringValidator;
            _tenantDbContextRouteFactory = tenantDbContextRouteFactory;
        }

        public async Task<ValidationResult> Handle(CreateCommand request, CancellationToken cancellationToken)
        {

            if (!_connectionStringValidator.IsValidConnectionString(request.ConnectionString))
            {
                AddError("A ConnectionString fornecida não é válida.");
                return ValidationResult;
            }

            var connectionStringDTO = _connectionStringValidator.GetHostAndDatabaseFromConnectionString(request.ConnectionString);

            var tenantExists = await _tenantRepository.GetByDbName(connectionStringDTO.Host, connectionStringDTO.DbName);

            if (tenantExists != null)
            {
                AddError("Já existe um tenant com o mesmo nome de banco de dados e host.");
                return ValidationResult;
            }
            
            await _tenantDbContextRouteFactory.CreateAndMigrateDbContextAsync(request.ConnectionString, cancellationToken);

            if (!_connectionStringValidator.TestConnectionString(request.ConnectionString))
            {
                AddError("Erro ao criar o banco de dados. Verifique a ConnectionString.");
                return ValidationResult;
            }

            var tenant = new Domain.Entities.Tenant(
                request.Id,
                request.Name,
                request.ConnectionString,
                request.TenantUrl
            );
            _tenantRepository.Add(tenant);

            return await Commit(_tenantRepository.UnitOfWork);;
        }
    }
}
