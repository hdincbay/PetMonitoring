using FluentValidation;
using PetMonitoring.Movement.Application.Queries;

namespace PetMonitoring.Movement.Application.Commands.AddHeartRate;

public class GetMovementValidator
    : AbstractValidator<GetMovementQuery>
{
    public GetMovementValidator()
    {
        RuleFor(x => x.DeviceId)
            .NotEmpty();
    }
}
