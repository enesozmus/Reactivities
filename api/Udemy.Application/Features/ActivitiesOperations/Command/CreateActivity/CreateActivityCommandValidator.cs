using FluentValidation;

namespace Udemy.Application.Features.ActivitiesOperations;

public class CreateActivityCommandValidator : AbstractValidator<CreateActivityCommandRequest>
{
     public CreateActivityCommandValidator()
     {
          RuleFor(x => x.Title).NotNull().WithMessage("Lütfen geçerli bir başlık giriniz!");
          RuleFor(x => x.Description).NotNull().WithMessage("Lütfen geçerli bir açıklama giriniz!");
          RuleFor(x => x.Category).NotNull().WithMessage("Lütfen geçerli bir kategori adı giriniz!");
          RuleFor(x => x.City).NotNull().WithMessage("Lütfen geçerli bir şehir adı giriniz!");
          RuleFor(x => x.Venue).NotNull().WithMessage("Lütfen geçerli bir mekan adı giriniz!");

          RuleFor(x => x.Title).NotEmpty();
          RuleFor(x => x.Description).NotEmpty();
          RuleFor(x => x.Category).NotEmpty();
          RuleFor(x => x.City).NotEmpty();
          RuleFor(x => x.Venue).NotEmpty();
     }
}
