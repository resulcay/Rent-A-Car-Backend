using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValiation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(cu => cu.CompanyName).NotEmpty().WithMessage("Can not be empty");
        }
    }
}
