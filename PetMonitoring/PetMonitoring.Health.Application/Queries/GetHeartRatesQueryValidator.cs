using FluentValidation;
using PetMonitoring.Health.Application.Queries;

namespace PetMonitoring.Health.Application.Commands.AddHeartRate;

public class GetHeartRatesQueryValidator
    : AbstractValidator<GetHeartRatesQuery>
{
    public GetHeartRatesQueryValidator()
    {
        RuleFor(x => x.DeviceSerialNumber)
            .NotEmpty();
    }
}
