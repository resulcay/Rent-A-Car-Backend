using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValiation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(cl => cl.ColorName).NotEmpty().WithMessage("Can not be empty");
        }
    }
}
