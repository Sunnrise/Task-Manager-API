using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerAPI.Domain.Entities.Identity;
using TaskManagerAPI.Domain.Entities;

namespace TaskManagerAPI.Application.Features.Duties.Commands.UpdateDuty
{
    public class UpdateDutyCommandRequest : IRequest<UpdateDutyCommandResponse>
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public Guid AppUserId { get; set; }
        public string Title { get; set; } // Görev başlığı
        public string Description { get; set; } // Görev açıklaması

    }
}
