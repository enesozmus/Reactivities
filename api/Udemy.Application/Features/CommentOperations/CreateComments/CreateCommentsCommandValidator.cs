using FluentValidation;

namespace Udemy.Application.Features.CommentOperations;

public class CreateCommentsCommandValidator : AbstractValidator<CreateCommentsCommandRequest>
{
     public CreateCommentsCommandValidator()
     {
          RuleFor(x => x.Body).NotNull().WithMessage("Lütfen geçerli bir yorum giriniz!");
          RuleFor(x => x.Body).NotEmpty().WithMessage("Lütfen geçerli bir yorum giriniz!");
     }
}
