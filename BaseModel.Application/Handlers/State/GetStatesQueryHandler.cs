using BaseModel.Application.Queries.State;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.States
{
    public class GetStatesQueryHandler : IRequestHandler<GetStatesQuery, IEnumerable<Domain.Entities.State>>
    {
        private readonly IStateRepository _stateRepository;
        public GetStatesQueryHandler(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<IEnumerable<Domain.Entities.State>> Handle(GetStatesQuery request, CancellationToken cancellationToken)
        {
            return await _stateRepository.GetAll();
        }
    }
}
