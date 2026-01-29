using FluentValidation;
using PetMonitoring.DeviceManagement.Application.Commands;

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
    }
}
