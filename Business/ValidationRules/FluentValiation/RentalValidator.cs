using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValiation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(c => c.RentDate).NotEmpty().WithMessage("Can not be empty");
        }
    }
}
