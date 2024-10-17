using FluentValidation;
using LibraryManagementSystem.Service.Users.ViewModels;

namespace LibraryManagementSystem.Service.Users.Validators
{
    public class UpdateProfileViewModelValidator : AbstractValidator<UpdateProfileViewModel>
    {
        public UpdateProfileViewModelValidator()
        {
            RuleFor(x => x.UserName)
                        .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
                        .MinimumLength(5).WithMessage("Kullanıcı adı en az 5 karakter olmalıdır.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Şehir ismi boş olamaz.")
                .MinimumLength(3).WithMessage("Şehir ismi en az 3 karakter olmalidir.");
        }
    }
}
