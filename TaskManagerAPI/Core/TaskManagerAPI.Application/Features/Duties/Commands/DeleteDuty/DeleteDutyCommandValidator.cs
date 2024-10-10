using FluentValidation;

namespace TaskManagerAPI.Application.Features.Duties.Commands.DeleteDuty
{
    public class DeleteDutyCommandValidator : AbstractValidator<DeleteDutyCommandRequest>
    {
        public DeleteDutyCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }

    }
}
