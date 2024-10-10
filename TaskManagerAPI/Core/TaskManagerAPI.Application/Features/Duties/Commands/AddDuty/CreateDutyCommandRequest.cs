using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAPI.Application.Features.Duties.Commands.AddDuty
{
    public class CreateDutyCommandRequest :IRequest<Unit>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int Status { get; set; }
        public Guid AppUserId { get; set; }
    }
}
