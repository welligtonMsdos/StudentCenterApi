using FluentValidation;
using StudentCenterApi._1___Model;

namespace StudentCenterApi.A___Validation;

public class StatusValidation : AbstractValidator<Status>
{
    public StatusValidation()
    {
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty");
        RuleFor(x => x.Description).MinimumLength(5).WithMessage("Description must be at least 5 characters");
        RuleFor(x => x.Description).MaximumLength(20).WithMessage("Description can be at most 20 characters");
    }
}
