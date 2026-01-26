using FluentValidation;
using PetMonitoring.Health.Application.Commands;

namespace PetMonitoring.Health.Application.Validators;

public class CreateHeartRateCommandValidator
    : AbstractValidator<CreateHeartRateCommand>
{
    public CreateHeartRateCommandValidator()
    {
        RuleFor(x => x.PetId)
            .NotEmpty();

        RuleFor(x => x.DeviceId)
            .NotEmpty();

        RuleFor(x => x.Bpm)
            .InclusiveBetween(30, 300);

        RuleFor(x => x.MeasuredAt)
            .LessThanOrEqualTo(DateTime.UtcNow);
    }
}
