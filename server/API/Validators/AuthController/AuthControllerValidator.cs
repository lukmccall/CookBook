using CookBook.API.Requests.AuthController;
using FluentValidation;

namespace CookBook.API.Validators.AuthController
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(request => request.Email)
                .EmailAddress()
                .NotEmpty()
                .NotNull();

            RuleFor(request => request.Password)
                .NotEmpty()
                .NotNull();
        }
    }
}