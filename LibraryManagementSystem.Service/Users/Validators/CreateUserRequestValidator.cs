
using FluentValidation;
using LibraryManagementSystem.Service.Users.DTOs;

namespace LibraryManagementSystem.Service.Users.Validators
{
    public class CreateUserRequestValidator: AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Password).Cascade(CascadeMode.Stop)
        .NotEmpty().WithMessage("Şifre boş olamaz.")
        .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
        .Must(password => password.Any(char.IsUpper)).WithMessage("Şifre en az bir büyük harf içermelidir.")
        .Must(password => password.Any(char.IsLower)).WithMessage("Şifre en az bir küçük harf içermelidir.")
        .Must(password => password.Any(c => !char.IsLetterOrDigit(c))).WithMessage("Şifre en az bir özel karakter içermelidir.");

            RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("E-posta boş olamaz.")
                    .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.City)
                    .NotEmpty().WithMessage("Şehir ismi boş olamaz.")
                    .MinimumLength(3).WithMessage("Şehir ismi en az 3 karakter olmalidir.");
        }
    }
}
