using AutoMapper;
using MediatR;
using TaskManagerAPI.Application.Features.Duties.Commands.UpdateDuty;
using TaskManagerAPI.Application.Interfaces.UnitOfWork;
using TaskManagerAPI.Domain.Entities;

namespace TaskManagerAPI.Application.Features.Duties.Commands.UpdateDutyStatus
{
    public class UpdateDutyStatusCommandHandler : IRequestHandler<UpdateDutyStatusCommandRequest, UpdateDutyStatusCommandResponse>
    {
        readonly IMapper mapper;
        readonly IUnitOfWork unitOfWork;

        public UpdateDutyStatusCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<UpdateDutyStatusCommandResponse> Handle(UpdateDutyStatusCommandRequest request, CancellationToken cancellationToken)
        {

            var duty = await unitOfWork.GetReadRepository<Duty>().GetAsync(d => d.Id == request.Id);

            var map = mapper.Map<Duty>(request);
            duty.Status = map.Status;
            await unitOfWork.GetWriteRepository<Duty>().UpdateAsync(duty); ;
            await unitOfWork.SaveAsync();

            return new();

        }
    }
}
