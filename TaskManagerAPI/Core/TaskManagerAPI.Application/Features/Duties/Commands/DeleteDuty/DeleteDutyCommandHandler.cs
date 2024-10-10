using MediatR;
using TaskManagerAPI.Application.Interfaces.UnitOfWork;
using TaskManagerAPI.Domain.Entities;

namespace TaskManagerAPI.Application.Features.Duties.Commands.DeleteDuty
{
    public class DeleteDutyCommandHandler : IRequestHandler<DeleteDutyCommandRequest, DeleteDutyCommandResponse>
    {
        IUnitOfWork unitOfWork;

        public DeleteDutyCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<DeleteDutyCommandResponse> Handle(DeleteDutyCommandRequest request, CancellationToken cancellationToken)
        {
            await unitOfWork.GetReadRepository<Duty>().GetAsync(d => d.Id == request.Id && !d.IsDeleted);
            await unitOfWork.GetWriteRepository<Duty>().DeleteAsync(request.Id);
            await unitOfWork.SaveAsync();
            return new();
        }
    }
    
}
