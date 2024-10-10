using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Application.Interfaces.UnitOfWork;
using TaskManagerAPI.Domain.Entities;

namespace TaskManagerAPI.Application.Features.Duties.Queries.GetDuties
{
    public class GetAllDutiesQueryHandler : IRequestHandler<GetAllDutiesByIdQueryRequest, IList<GetAllDutiesByIdQueryResponse>>
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;

        public GetAllDutiesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetAllDutiesByIdQueryResponse>> Handle(GetAllDutiesByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var duties=  await unitOfWork.GetReadRepository<Duty>().GetAllAsync();
            var result = mapper.Map<List<GetAllDutiesByIdQueryResponse>>(duties);
            return result;
        }
    }

}
