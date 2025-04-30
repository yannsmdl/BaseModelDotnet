using BaseModel.Application.Commands.Tenant;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.Tenant
{
    public class UpdateTenantCommandHandler : CommandHandler, IRequestHandler<UpdateCommand, ValidationResult>
    {
        private readonly ITenantRepository _tenantRepository;
        public UpdateTenantCommandHandler
        (
            ITenantRepository tenantRepository
        )
        {
            _tenantRepository = tenantRepository;
        }

        public async Task<ValidationResult> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            // Desativado para evitar que o tenant seja atualizado
            return await Commit(_tenantRepository.UnitOfWork);
        }
    }
}
