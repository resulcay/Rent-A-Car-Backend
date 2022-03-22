using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValiation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(br => br.BrandName).NotEmpty().WithMessage("Can not be empty");
        }
    }
}
