using FluentValidation;
using PetMonitoring.Movement.Application.Commands;

namespace PetMonitoring.Health.Application.Validators;

public class CreateMovementCommandValidator
    : AbstractValidator<CreateMovementCommand>
{
    public CreateMovementCommandValidator()
    {
        RuleFor(x => x.PetId)
            .NotEmpty();

        RuleFor(x => x.DeviceId)
            .NotEmpty();
    }
}
