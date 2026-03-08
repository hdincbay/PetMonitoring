using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace PetMonitoring.DeviceManagement.Application.Commands.UpdateDeviceCommand;

public class UpdateDeviceCommandValidator
    : AbstractValidator<UpdateDeviceCommand>
{
    public UpdateDeviceCommandValidator()
    {
        RuleFor(x => x.ID)
            .NotEmpty();
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
