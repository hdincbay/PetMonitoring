using FluentValidation;
using PetMonitoring.Movement.Application.Commands.AddMovement;

namespace PetMonitoring.Movement.Application.Validators;

public class AddMovementCommandValidator
    : AbstractValidator<AddMovementCommand>
{
    public AddMovementCommandValidator()
    {
        RuleFor(x => x.DeviceSerialNumber)
            .NotEmpty();
    }
}
