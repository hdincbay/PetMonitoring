using FluentValidation;
using PetMonitoring.Movement.Application.Queries;

namespace PetMonitoring.Movement.Application.Commands.AddHeartRate;

public class GetMovementsValidator
    : AbstractValidator<GetMovementsQuery>
{
    public GetMovementsValidator()
    {
        RuleFor(x => x.DeviceSerialNumber)
            .NotEmpty();
    }
}
