using AutoMapper;
using MediatR;
using TaskManagerAPI.Application.Interfaces.UnitOfWork;
using TaskManagerAPI.Domain.Entities;

namespace TaskManagerAPI.Application.Features.Duties.Commands.UpdateDuty
{
    public class UpdateDutyCommandHandler : IRequestHandler<UpdateDutyCommandRequest, UpdateDutyCommandResponse>
    {

        readonly IMapper mapper;
        readonly IUnitOfWork unitOfWork;

        public UpdateDutyCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<UpdateDutyCommandResponse> Handle(UpdateDutyCommandRequest request, CancellationToken cancellationToken)
        {
            var duty = await unitOfWork.GetReadRepository<Duty>().GetAsync(d => d.Id == request.Id);

            var map = mapper.Map<Duty>(request);


            await unitOfWork.GetWriteRepository<Duty>().UpdateAsync(map);
            await unitOfWork.SaveAsync();

            return new();
        }
    }
}