using FluentValidation;
using StudentCenterApi.src.Domain.Model;

namespace StudentCenterApi.src.Domain.Validation;

public class StudentCenterBaseValidation : AbstractValidator<StudentCenterBase>
{
    public StudentCenterBaseValidation()
    {
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty");
        RuleFor(x => x.Description).MinimumLength(5).WithMessage("Description must be at least 5 characters");
        RuleFor(x => x.Description).MaximumLength(20).WithMessage("Description can be at most 20 characters");
        RuleFor(x => x.Page).MinimumLength(5).WithMessage("Page must be at least 5 characters");
        RuleFor(x => x.Page).MaximumLength(20).WithMessage("Page can be at most 20 characters");
    }
}
