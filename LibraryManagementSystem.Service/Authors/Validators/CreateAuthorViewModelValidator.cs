using FluentValidation;
using LibraryManagementSystem.Service.Authors.ViewModels;

namespace LibraryManagementSystem.Service.Authors.Validators
{
    public class CreateAuthorViewModelValidator : AbstractValidator<CreateAuthorViewModel>
    {
        public CreateAuthorViewModelValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Yazar ismi gereklidir");
            RuleFor(x => x.Name)
            .MinimumLength(2).WithMessage("Yazar ismi en az 3 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Yazar ismi en fazla 100 karakter olabilir.");

        }
    }
}
