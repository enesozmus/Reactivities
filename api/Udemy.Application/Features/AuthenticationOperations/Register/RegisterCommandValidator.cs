using FluentValidation;
using System.Text.RegularExpressions;

namespace Udemy.Application.Features.AuthenticationOperations;

public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
{
     public RegisterCommandValidator()
     {
          RuleFor(p => p.FirstName).NotNull().NotEmpty().WithMessage("Kayıt olabilmek için ad alanını lütfen doldurun!");
          RuleFor(p => p.LastName).NotNull().NotEmpty().WithMessage("Kayıt olabilmek için soyadı alanını lütfen doldurun!");
          RuleFor(p => p.UserName).NotNull().NotEmpty().WithMessage("Kayıt olabilmek için kullanıcı adı alanını lütfen doldurun!");
          RuleFor(p => p.Email).NotNull().NotEmpty().WithMessage("Kayıt olabilmek için email alanını lütfen doldurun!");
          RuleFor(p => p.Password).NotNull().NotEmpty().WithMessage("Kayıt olabilmek için parola alanını lütfen doldurun!");

          RuleFor(p => p.FirstName).MinimumLength(2).WithMessage("Ad alanı 2 karakterden az olmamalı!");
          RuleFor(p => p.LastName).MinimumLength(2).WithMessage("Soyadı alanı 2 karakterden az olmamalı!");
          RuleFor(p => p.UserName).MinimumLength(2).WithMessage("Kullanıcı adı alanı 2 karakterden az olmamalı!");
          RuleFor(p => p.Email).MinimumLength(8).WithMessage("Email alanı 8 karakterden az olmamalı!");
          RuleFor(p => p.Password).MinimumLength(8).WithMessage("Parola alanı 8 karakterden az olmamalı!");

          RuleFor(p => p.FirstName).MaximumLength(15).WithMessage("Ad alanı 15 karakterden fazla olmamalı");
          RuleFor(p => p.LastName).MaximumLength(15).WithMessage("Soyadı alanı 15 karakterden fazla olmamalı");
          RuleFor(p => p.UserName).MaximumLength(20).WithMessage("Kullanıcı adı alanı 20 karakterden fazla olmamalı");
          RuleFor(p => p.Email).MaximumLength(20).WithMessage("Email alanı 20 karakterden fazla olmamalı");
          RuleFor(p => p.Password).MaximumLength(20).WithMessage("Parola alanı 20 karakterden fazla olmamalı");

          RuleFor(p => p.Email).EmailAddress().WithMessage("Lütfen bir email formatı kullanınız!");

          RuleFor(x => x.PhoneNumber).MaximumLength(13).MinimumLength(13).WithMessage("Telefon numarası 13 karakterli olmalıdır!"); 
          RuleFor(x => x.PhoneNumber).Matches("(05|5)[0-9][0-9][ ][1-9]([0-9]){2}[ ]([0-9]){4}").WithMessage("Lütfen 05xx xxx xxxx formatını kullanınız.");

          RuleFor(p => p.Password).Must(p => HasValidPassword(p)).WithMessage("Parola bir rakam[0-9], büyük[A-Z] ve küçük karakter[a-z] ve alfanümerik olmayan bir karakter içermelidir.");
     }

     private bool HasValidPassword(string pw)
     {
          var lowercase = new Regex("[a-z]+");
          var uppercase = new Regex("[A-Z]+");
          var digit = new Regex("(\\d)+");
          var symbol = new Regex("(\\W)+");

          return (lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw) && symbol.IsMatch(pw));
     }
}
