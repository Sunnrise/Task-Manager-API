using AutoMapper;
using MediatR;
using TaskManagerAPI.Application.Interfaces.UnitOfWork;
using TaskManagerAPI.Domain.Entities;

namespace TaskManagerAPI.Application.Features.Duties.Commands.AddDuty
{
    public class CreateDutyCommandHandler : IRequestHandler<CreateDutyCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateDutyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateDutyCommandRequest request, CancellationToken cancellationToken)
        {  
            var map= mapper.Map<Duty>(request);

                await unitOfWork.GetWriteRepository<Duty>().AddAsync(map);
                await unitOfWork.SaveAsync();
            return new();
        }
    }
}
