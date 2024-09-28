using FluentValidation;
using LibraryManagementSystem.WebApp.Models.ViewModels;

namespace LibraryManagementSystem.WebApp.Validations
{
    public class CreateBookViewModelValidator: AbstractValidator<CreateBookViewModel>
    {
        public CreateBookViewModelValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Kitap ismi gereklidir");
            RuleFor(x => x.Title)
            .MinimumLength(2).WithMessage("Kitap ismi en az 2 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Kitap ismi en fazla 100 karakter olabilir.");

            RuleFor(x => x.Summary).NotNull().WithMessage("Kitap özeti gereklidir");
            RuleFor(x => x.Summary)
            .MinimumLength(10).WithMessage("Kitap özeti en az 10 karakter olmalıdır.")
            .MaximumLength(1000).WithMessage("Kitap ismi en fazla 1000 karakter olabilir.");

            RuleFor(x => x.Author).NotNull().WithMessage("Yazar ismi gereklidir");
            RuleFor(x => x.Author)
            .MinimumLength(5).WithMessage("Yazar ismi en az 5 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Yazar ismi en fazla 50 karakter olabilir.");


            RuleFor(x => x.PublicationYear).NotNull().WithMessage("Yayın yılı gereklidir");
            RuleFor(x => x.PublicationYear)
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage($"Yayın yılı {DateTime.Now.Year}'den büyük olamaz.");

            RuleFor(x => x.ISBN)
            .NotNull().WithMessage("ISBN numarası gereklidir.")
            .Length(13).WithMessage("ISBN numarası 13 haneli olmalıdır.")
            .Matches("^[0-9]+$").WithMessage("ISBN numarası sadece rakamlardan oluşmalıdır.");

            RuleFor(x => x.Genre).NotNull().WithMessage("Kitap türü gereklidir");
            RuleFor(x => x.Genre)
            .MaximumLength(100).WithMessage("Kitap türü en fazla 20 karakter olabilir.");

            RuleFor(x => x.Publisher).NotNull().WithMessage("Yayıncı gereklidir");
            RuleFor(x => x.Publisher)
            .MaximumLength(100).WithMessage("Yayıncı en fazla 100 karakter olabilir.");

            RuleFor(x => x.PageCount).NotNull().WithMessage("Sayfa sayısı gereklidir");
            RuleFor(x => x.PageCount)
            .GreaterThan(0).WithMessage("Sayfa sayısı 0 dan büyük olmadlıdır.");

            RuleFor(x => x.Language).NotNull().WithMessage("Yazıldığı dil gereklidir");
            RuleFor(x => x.Language)
            .MaximumLength(100).WithMessage("Yazıldığı dil en fazla 100 karakter olabilir.");

            RuleFor(x => x.AvailableCopies).NotNull().WithMessage("Mevcut kopya sayısı gereklidir");
            RuleFor(x => x.AvailableCopies)
            .GreaterThan(0).WithMessage("Mevcut kopya sayısı 0 dan büyük olmadlıdır.");

            RuleFor(x => x.ImageFile)
            .NotNull().WithMessage("Bir resim dosyası yüklemeniz gerekmektedir.")
            .Must(file => file.Length > 0).WithMessage("Bir resim dosyası yüklemeniz gerekmektedir.");
        }
    }
}
