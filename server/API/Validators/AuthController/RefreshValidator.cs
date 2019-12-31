using CookBook.API.Requests.AuthController;
using FluentValidation;

namespace CookBook.API.Validators.AuthController
{
    public class RefreshValidator : AbstractValidator<RefreshRequest>
    {
        public RefreshValidator()
        {
            RuleFor(x => x.Token)
                .NotEmpty();

            RuleFor(x => x.RefreshToken)
                .NotEmpty();
        }
    }
}