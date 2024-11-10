using FluentValidation;
using LibraryManagementSystem.Service.Users.DTOs;

namespace LibraryManagementSystem.Service.Users.Validators
{
    public class UpdateUserRequestValidator:AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {

            RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("E-posta boş olamaz.")
                    .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.City)
                    .NotEmpty().WithMessage("Şehir ismi boş olamaz.")
                    .MinimumLength(3).WithMessage("Şehir ismi en az 3 karakter olmalidir.");
        }
    }
}
