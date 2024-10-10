using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAPI.Application.Features.Duties.Queries.GetDuties
{
    public class GetAllDutiesByIdQueryRequest : IRequest<IList<GetAllDutiesByIdQueryResponse>>
    {
        
    }

}
