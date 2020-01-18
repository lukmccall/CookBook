using System;
using System.IO;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace CookBook.API.Validators.UserController
{
    public class FileValidator : AbstractValidator<FormFile>
    {

        public FileValidator()
        {
            RuleFor(x => x)
                .Must(x => x.Length < 5000000)
                .WithMessage("File should have max 5Mb.")
                .Must(x =>
                {
                    var extension = Path.GetExtension(x.FileName);
                    return string.Compare(".png", extension, StringComparison.OrdinalIgnoreCase) == 0 ||
                           string.Compare(".jpg", extension, StringComparison.OrdinalIgnoreCase) == 0;
                })
                .WithMessage("File must have extension.")
                .Must(x => x.ContentType == "image/jpeg" || x.ContentType == "image/png")
                .WithMessage("File should be a image.");
        }

    }
}
