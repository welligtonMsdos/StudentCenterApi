using FluentValidation;
using StudentCenterApi.src.Domain.Enum;
using StudentCenterApi.src.Domain.Model;

namespace StudentCenterApi.src.Domain.Validation;

public class StatusValidation : AbstractValidator<Status>
{
    public StatusValidation()
    {       
        RuleFor(x => x.Description).NotEmpty().WithMessage(EMsgValidation.MSG_REQUIRED);
        RuleFor(x => x.Description).MinimumLength(5).WithMessage(string.Format(EMsgValidation.MSG_MIN_LENGTH, 5));
        RuleFor(x => x.Description).MaximumLength(20).WithMessage(string.Format(EMsgValidation.MSG_MAX_LENGTH, 20));
    }
}
