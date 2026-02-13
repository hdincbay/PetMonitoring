using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace PetMonitoring.DeviceManagement.Application.Commands.AddDeviceCommand;

public class UpdateDeviceCommandValidator
    : AbstractValidator<CreateDeviceCommand>
{
    public UpdateDeviceCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
