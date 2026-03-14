using FluentValidation;
using PetMonitoring.Temperature.Application.Queries;

namespace PetMonitoring.Temperature.Application.Commands.AddHeartRate;

public class GetTemperaturesQueryValidator
    : AbstractValidator<GetTemperaturesQuery>
{
    public GetTemperaturesQueryValidator()
    {
        RuleFor(x => x.DeviceSerialNumber)
            .NotEmpty();
    }
}
