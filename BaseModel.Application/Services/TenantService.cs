using AutoMapper;
using BaseModel.Application.Commands.Tenant;
using BaseModel.Application.DTOs;
using BaseModel.Application.Interfaces;
using BaseModel.Application.Queries.Tenant;
using BaseModel.Application.Shareds;
using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Services
{
    public class TenantService : ITenantService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public TenantService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<TenantDTO>> GetAll()
        {
            var tenantQuery = new GetAllQuery();
            var tenant = await _mediator.Send(tenantQuery);
            return _mapper.Map<IEnumerable<TenantDTO>>(tenant);
        }

        public async Task<TenantDTO?> GetById(Guid Id)
        {
            var tenantQuery = new GetByIdQuery(Id);
            var tenant = await _mediator.Send(tenantQuery);
            return _mapper.Map<TenantDTO>(tenant);
        }

        public async Task<TenantDTO?> GetByTenantUrl(string tenantUrl)
        {
            var tenantQuery = new GetByTenantUrlQuery(tenantUrl);
            var tenant = await _mediator.Send(tenantQuery);
            return _mapper.Map<TenantDTO?>(tenant);
        }

        public async Task<ValidationResult> Remove(Guid Id)
        {
            var tenantRemoveCommand = new RemoveCommand(Id);
            var validationResult = await _mediator.Send(tenantRemoveCommand);
            return validationResult;
        }

        public async Task<ValidationResult> Update(TenantDTO tenant)
        {
            var tenantUpdateCommand = _mapper.Map<UpdateCommand>(tenant);
            var validationResult = await _mediator.Send(tenantUpdateCommand);
            return validationResult;
        }

        public async Task<ValidationResultWithData<Guid>> Add(TenantDTO tenant)
        {
            tenant.Id = Guid.NewGuid();
            var tenantCreateCommand = _mapper.Map<CreateCommand>(tenant);
            var validationResult = await _mediator.Send(tenantCreateCommand);
            return new ValidationResultWithData<Guid>(validationResult, tenant.Id);
        }
    }
}
