using FluentValidation;
using StudentCenterApi._1___Model;

namespace StudentCenterApi.A___Validation;

public class SolicitationValidation : AbstractValidator<Solicitation>
{
    public SolicitationValidation()
    {
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty");
        RuleFor(x => x.Description).MinimumLength(20).WithMessage("Description must be at least 20 characters");
        RuleFor(x => x.Description).MaximumLength(300).WithMessage("Description can be at most 300 characters");
        RuleFor(c => c.StatusId).NotEmpty().WithMessage("StatusId cannot be empty");
        RuleFor(c => c.RequestTypeId).NotEmpty().WithMessage("RequestTypeId cannot be empty");
        RuleFor(c => c.StudentId).NotEmpty().WithMessage("StudentId cannot be empty");
    }
}
