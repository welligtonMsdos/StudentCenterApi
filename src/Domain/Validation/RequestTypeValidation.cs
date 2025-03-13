using FluentValidation;
using StudentCenterApi.src.Domain.Model;

namespace StudentCenterApi.src.Domain.Validation;

public class RequestTypeValidation : AbstractValidator<RequestType>
{
    public RequestTypeValidation()
    {
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty");
        RuleFor(x => x.Description).MinimumLength(5).WithMessage("Description must be at least 5 characters");
        RuleFor(x => x.Description).MaximumLength(100).WithMessage("Description can be at most 100 characters");
    }
}
