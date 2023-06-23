using FluentValidation;
using MercedesURLShortener.Core.DTOs;

namespace MercedesURLShortener.Service.Validations
{
    public class UrlDtoValidator : AbstractValidator<UrlDto>
    {
        public UrlDtoValidator()
        {
            RuleFor(x => x.CurrentUrl).NotNull().WithMessage("{PropertyName}, is required!").NotEmpty().WithMessage("{PropertyName}, is required!");
        }
    }
}