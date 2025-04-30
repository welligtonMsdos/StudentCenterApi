using FluentValidation;
using StudentCenterApi.src.Domain.Enum;
using StudentCenterApi.src.Domain.Model;

namespace StudentCenterApi.src.Domain.Validation;

public class SolicitationValidation : AbstractValidator<Solicitation>
{
    public SolicitationValidation()
    {
        RuleFor(x => x.Description).NotEmpty().WithMessage(EMsgValidation.MSG_REQUIRED);
        RuleFor(x => x.Description).MinimumLength(20).WithMessage(string.Format(EMsgValidation.MSG_MIN_LENGTH, 20));
        RuleFor(x => x.Description).MaximumLength(300).WithMessage(string.Format(EMsgValidation.MSG_MAX_LENGTH, 300));
        RuleFor(c => c.RequestTypeId).NotEmpty().WithMessage(EMsgValidation.MSG_REQUIRED);
        RuleFor(c => c.StudentId).NotEmpty().WithMessage(EMsgValidation.MSG_REQUIRED);
    }
}
