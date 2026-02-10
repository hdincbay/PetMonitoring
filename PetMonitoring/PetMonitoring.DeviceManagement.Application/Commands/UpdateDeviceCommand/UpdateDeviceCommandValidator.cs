using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace PetMonitoring.DeviceManagement.Application.Commands.UpdateDeviceCommand;

public class UpdateDeviceCommandValidator
    : AbstractValidator<UpdateDeviceCommand>
{
    public UpdateDeviceCommandValidator()
    {
        RuleFor(x => x.DeviceId)
            .NotEmpty();
        RuleFor(x => x.BatteryPercentage)
            .NotEmpty();
    }
}
