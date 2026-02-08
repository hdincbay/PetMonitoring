using FluentValidation;
using PetMonitoring.Health.Application.Queries;

namespace PetMonitoring.Health.Application.Commands.AddHeartRate;

public class GetHeartRateQueryValidator
    : AbstractValidator<GetHeartRateQuery>
{
    public GetHeartRateQueryValidator()
    {
        RuleFor(x => x.DeviceId)
            .NotEmpty();
    }
}
