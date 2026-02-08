using FluentValidation;

namespace PetMonitoring.Health.Application.Commands.UpdateHeartRate;

public class UpdateHeartRateCommandValidator
    : AbstractValidator<UpdateHeartRateCommand>
{
    public UpdateHeartRateCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Bpm)
            .InclusiveBetween(30, 300);
    }
}
