using FluentValidation;

namespace PetMonitoring.DeviceManagement.Application.Queries;
public class GetDeviceQueryValidator
    : AbstractValidator<GetDeviceQuery>
{
    public GetDeviceQueryValidator()
    {
        RuleFor(x => x.DeviceId)
            .NotEmpty();
    }
}
