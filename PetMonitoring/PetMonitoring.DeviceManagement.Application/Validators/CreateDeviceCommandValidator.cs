using FluentValidation;
using PetMonitoring.DeviceManagement.Application.Commands;
using System.ComponentModel.DataAnnotations;

namespace PetMonitoring.Health.Application.Validators;

public class CreateDeviceCommandValidator
    : AbstractValidator<CreateDeviceCommand>
{
    public CreateDeviceCommandValidator()
    {
        RuleFor(x => x.PetId)
            .NotEmpty();

        RuleFor(x => x.CreatedDate)
            .LessThanOrEqualTo(DateTime.UtcNow);

        RuleFor(x => x.BatteryPercentage)
            .InclusiveBetween(0, 100)
            .WithMessage("Battery percentage must be between 0 and 100.");
    }
}
