using FluentValidation;
using PetMonitoring.Temperature.Application.Queries;

namespace PetMonitoring.Temperature.Application.Commands.AddHeartRate;

public class GetTemperatureQueryValidator
    : AbstractValidator<GetTemperatureQuery>
{
    public GetTemperatureQueryValidator()
    {
        RuleFor(x => x.DeviceId)
            .NotEmpty();
    }
}
