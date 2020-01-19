using CookBook.API.Requests.CommentsController;
using FluentValidation;

namespace CookBook.API.Validators.CommentsController
{
    public class CommentsValidator : AbstractValidator<CommentRequest>
    {

        public CommentsValidator()
        {
            RuleFor(x => x.Body)
                .NotEmpty()
                .MaximumLength(250);
        }

    }
}
