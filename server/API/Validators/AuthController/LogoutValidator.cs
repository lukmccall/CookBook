using CookBook.API.Requests.AuthController;
using FluentValidation;

namespace CookBook.API.Validators.AuthController
{
    public class LogoutValidator : AbstractValidator<LogoutRequest>
    {

        public LogoutValidator()
        {
            RuleFor(x => x.Token)
                .NotEmpty();
        }

    }
}
