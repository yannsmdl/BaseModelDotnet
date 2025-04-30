using BaseModel.Application.Queries.State;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.State
{
    public class GetStateByIdQueryHandler : IRequestHandler<GetStateByIdQuery, Domain.Entities.State?>
    {
        private readonly IStateRepository _stateRepository;
        public GetStateByIdQueryHandler(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        public async Task<Domain.Entities.State?> Handle(GetStateByIdQuery request, CancellationToken cancellationToken)
        {
            return await _stateRepository.GetById(request.Id);
        }
    }
}
