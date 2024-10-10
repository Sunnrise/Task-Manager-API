using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerAPI.Application.Features.Duties.Commands.AddDuty;
using TaskManagerAPI.Application.Features.Duties.Commands.UpdateDuty;
using TaskManagerAPI.Application.Features.Duties.Commands.UpdateDutyStatus;
using TaskManagerAPI.Application.Features.Duties.Queries.GetDuties;

namespace TaskManagerAPI.Application.AutoMapper.Duty
{
    public class DutyProfile : Profile
    {
        public DutyProfile()
        {
            CreateMap<CreateDutyCommandRequest, Domain.Entities.Duty>();
            CreateMap<UpdateDutyCommandRequest, Domain.Entities.Duty>().ReverseMap();
            CreateMap<Domain.Entities.Duty, GetAllDutiesByIdQueryResponse>();
            CreateMap<Domain.Entities.Duty, GetAllDutiesByIdQueryResponse>();
            CreateMap<Domain.Entities.Duty, UpdateDutyStatusCommandRequest>().ReverseMap();
        }
    }
}
