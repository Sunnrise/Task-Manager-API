using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAPI.Application.Features.Duties.Commands.DeleteDuty
{
    public class DeleteDutyCommandRequest : IRequest<DeleteDutyCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
