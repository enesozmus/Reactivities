using FluentValidation;

namespace Udemy.Application.Features.ActivitiesOperations;

public class UpdateActivityCommandValidator : AbstractValidator<UpdateActivityCommandRequest>
{
     public UpdateActivityCommandValidator()
     {
          RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("Lütfen geçerli bir başlık giriniz!");
          RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Lütfen geçerli bir açıklama giriniz!");
          RuleFor(x => x.Category).NotNull().NotEmpty().WithMessage("Lütfen geçerli bir kategori adı giriniz!");
          RuleFor(x => x.City).NotNull().NotEmpty().WithMessage("Lütfen geçerli bir şehir adı giriniz!");
          RuleFor(x => x.Venue).NotNull().NotEmpty().WithMessage("Lütfen geçerli bir mekan adı giriniz!");
     }
}
