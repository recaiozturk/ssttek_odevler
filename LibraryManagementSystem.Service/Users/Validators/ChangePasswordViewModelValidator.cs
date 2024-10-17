using AutoMapper;
using FluentValidation;
using LibraryManagementSystem.Service.Users.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Service.Users.Validators
{
    public class ChangePasswordViewModelValidator : AbstractValidator<ChangePasswordViewModel>
    {
        public ChangePasswordViewModelValidator()
        {
            RuleFor(x => x.OldPassword).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Şifre boş olamaz.");

            RuleFor(x => x.Password).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Şifre boş olamaz.")
            .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
            .Must(password => password.Any(char.IsUpper)).WithMessage("Şifre en az bir büyük harf içermelidir.")
            .Must(password => password.Any(char.IsLower)).WithMessage("Şifre en az bir küçük harf içermelidir.")
            .Must(password => password.Any(c => !char.IsLetterOrDigit(c))).WithMessage("Şifre en az bir özel karakter içermelidir.");

            RuleFor(r => r.RePassword)
                 .Equal(r => r.Password).WithMessage("Şifreler eşleşmiyor");

        }
    }
}
