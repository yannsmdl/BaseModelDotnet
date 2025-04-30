using BaseModel.Application.Commands.Tenant;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.Tenant
{
    public class RemoveTenantCommandHandler : CommandHandler, IRequestHandler<RemoveCommand, ValidationResult>
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IDatabaseManager _databaseManager;
        private readonly IConnectionStringValidator _connectionStringValidator;
        public RemoveTenantCommandHandler(ITenantRepository tenantRepository, IDatabaseManager databaseManager, IConnectionStringValidator connectionStringValidator)
        {
            _tenantRepository = tenantRepository;
            _databaseManager = databaseManager;
            _connectionStringValidator = connectionStringValidator;
        }

        public async Task<ValidationResult> Handle(RemoveCommand request, CancellationToken cancellationToken)
        {
            var tenant = await _tenantRepository.GetById(request.Id);
            if (tenant == null)
            {
                AddError("Tenant não existe");
                return ValidationResult;
            }
            await _databaseManager.DropDatabaseAsync(tenant.ConnectionString);
            if (_connectionStringValidator.TestConnectionString(tenant.ConnectionString))
            {
                AddError("Erro ao deletar o banco");
                return ValidationResult;
            }

            _tenantRepository.Remove(tenant);
            return await Commit(_tenantRepository.UnitOfWork);
        }
    }
}
