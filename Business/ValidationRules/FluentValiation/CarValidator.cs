using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValiation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).NotEmpty().WithMessage("Can not be empty");
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.DailyPrice).GreaterThan(10);
            RuleFor(c => c.Description).Must(StartWithA);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("a");
        }

    }
}
