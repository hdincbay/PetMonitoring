using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace PetMonitoring.DeviceManagement.Application.Commands.BatteryUpdateCommand;

public class BatteryUpdateCommandValidator
    : AbstractValidator<BatteryUpdateCommand>
{
    public BatteryUpdateCommandValidator()
    {
        RuleFor(x => x.ID)
            .NotEmpty();
        RuleFor(x => x.BatteryPercentage)
            .NotEmpty();
    }
}
