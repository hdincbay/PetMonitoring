using FluentValidation;

namespace PetMonitoring.Health.Application.Commands.AddHeartRate;

public class AddHeartRateCommandValidator
    : AbstractValidator<AddHeartRateCommand>
{
    public AddHeartRateCommandValidator()
    {

        RuleFor(x => x.DeviceSerialNumber)
            .NotEmpty();

        RuleFor(x => x.Bpm)
            .InclusiveBetween(30, 300);
    }
}
