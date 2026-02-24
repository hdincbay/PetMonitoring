using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace PetMonitoring.DeviceManagement.Application.Commands.CreateDeviceCommand;

public class CreateDeviceCommandValidator
    : AbstractValidator<CreateDeviceCommand>
{
    public CreateDeviceCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
