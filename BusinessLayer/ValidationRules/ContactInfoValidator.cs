using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactInfoValidator : AbstractValidator<Contact>
    {
        public ContactInfoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bu alan boş olamaz")
                .MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz.")
                .MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz.");

            RuleFor(x => x.Phone).NotEmpty().WithMessage("Bu alan boş olamaz")
                  .MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz.")
                  .MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter giriniz.");

            RuleFor(x => x.Mail).NotEmpty().WithMessage("Bu alan boş olamaz")
                  .MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz.")
                  .MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz.")
                  .EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Bu alan boş olamaz")
                  .MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz.")
                  .MaximumLength(500).WithMessage("Lütfen en fazla 500 karakter giriniz.");
        }
    }
}
