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
                .NotEmpty();

            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(40);

            RuleFor(x => x.Password)
                .NotEmpty();
        }

    }
}
