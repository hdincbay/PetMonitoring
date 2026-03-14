using FluentValidation;

namespace PetMonitoring.Temperature.Application.Commands.AddTemperature;

public class AddTemperatureCommandValidator
    : AbstractValidator<AddTemperatureCommand>
{
    public AddTemperatureCommandValidator()
    {
        RuleFor(x => x.DeviceSerialNumber)
            .NotEmpty();

        RuleFor(x => x.CelsiusValue)
            .NotEmpty();
    }
}
