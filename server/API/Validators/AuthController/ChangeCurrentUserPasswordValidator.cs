using CookBook.API.Requests.AuthController;
using FluentValidation;

namespace CookBook.API.Validators.AuthController
{
    public class ChangeCurrentUserPasswordValidator : AbstractValidator<ChangeCurrentUserPasswordRequest>
    {
        public ChangeCurrentUserPasswordValidator()
        {
            RuleFor(x => x.NewPassword)
                .NotEmpty();

            RuleFor(x => x.OldPassword)
                .NotEmpty();
        }
    }
}