using CookBook.API.Requests.AuthController;
using FluentValidation;

namespace CookBook.API.Validators.AuthController
{
    public class RegisterValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(40);

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty();
        }
    }
}