using FluentValidation;
using PetMonitoring.Temperature.Application.Commands;

namespace PetMonitoring.Temperature.Application.Validators;

public class CreateTemperatureCommandValidator
    : AbstractValidator<CreateTemperatureCommand>
{
    public CreateTemperatureCommandValidator()
    {
        RuleFor(x => x.PetId)
            .NotEmpty();

        RuleFor(x => x.DeviceId)
            .NotEmpty();

        RuleFor(x => x.CreatedDate)
            .LessThanOrEqualTo(DateTime.UtcNow);
    }
}
