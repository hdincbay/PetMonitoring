using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace PetMonitoring.DeviceManagement.Application.Commands.CreateDeviceCommand;

public class UpdateDeviceCommandValidator
    : AbstractValidator<CreateDeviceCommand>
{
    public UpdateDeviceCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
