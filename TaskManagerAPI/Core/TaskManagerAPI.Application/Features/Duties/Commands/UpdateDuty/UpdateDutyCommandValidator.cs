using FluentValidation;

namespace TaskManagerAPI.Application.Features.Duties.Commands.UpdateDuty
{
    public class UpdateDutyCommandValidator : AbstractValidator<UpdateDutyCommandRequest>
    {
        public UpdateDutyCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
            RuleFor(x => x.AppUserId).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
