using AutoMapper;
using BaseModel.Application.Commands.Profession;
using BaseModel.Application.DTOs;
using BaseModel.Application.Interfaces;
using BaseModel.Application.Queries.Profession;
using BaseModel.Application.Shareds;
using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Services
{
    public class ProfessionService : IProfessionService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProfessionService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProfessionDTO>> GetAll()
        {
            var professionQuery = new GetAllQuery();
            var profession = await _mediator.Send(professionQuery);
            return _mapper.Map<IEnumerable<ProfessionDTO>>(profession);
        }

        public async Task<ProfessionDTO?> GetById(Guid Id)
        {
            var professionQuery = new GetByIdQuery(Id);
            var profession = await _mediator.Send(professionQuery);
            return _mapper.Map<ProfessionDTO>(profession);
        }

        public async Task<ValidationResult> Remove(Guid Id)
        {
            var professionRemoveCommand = new RemoveCommand(Id);
            return await _mediator.Send(professionRemoveCommand);
        }

        public async Task<ValidationResult> Update(ProfessionDTO profession)
        {
            var professionUpdateCommand = _mapper.Map<UpdateCommand>(profession);
            return await _mediator.Send(professionUpdateCommand);
        }

        public async Task<ValidationResultWithData<Guid>> Add(ProfessionDTO profession)
        {
            profession.Id = Guid.NewGuid();
            var professionCreateCommand = _mapper.Map<CreateCommand>(profession);
            var validationResult = await _mediator.Send(professionCreateCommand);
            return new ValidationResultWithData<Guid>(validationResult, profession.Id);
        }
    }
}
