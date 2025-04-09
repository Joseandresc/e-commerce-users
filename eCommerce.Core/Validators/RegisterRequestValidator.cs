using eCommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 6 characters long.");
            RuleFor(x => x.PersonName)
                .NotEmpty().WithMessage("Person name is required.")
                .MinimumLength(1).WithMessage("Name should be at least 1 character long.")
                .MaximumLength(50).WithMessage("Name should not exceed 50 characters.");
            RuleFor(x => x.Gender)
                .IsInEnum<RegisterRequest, GenderOptions>();

        }
    }
}
