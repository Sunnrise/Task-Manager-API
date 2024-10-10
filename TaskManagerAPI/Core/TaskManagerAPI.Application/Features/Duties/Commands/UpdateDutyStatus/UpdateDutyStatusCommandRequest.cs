using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAPI.Application.Features.Duties.Commands.UpdateDutyStatus
{
    public class UpdateDutyStatusCommandRequest : IRequest<UpdateDutyStatusCommandResponse>
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
    }
}
