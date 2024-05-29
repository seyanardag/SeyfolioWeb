using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator :AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Bu alan zorunludur.")
                .MinimumLength(3).WithMessage("En az 3 karakter giriniz.")
                .MaximumLength(30).WithMessage("En fazla 30 karakter giriniz.");
                
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Bu alan zorunludur.")
                .MinimumLength(3).WithMessage("En az 3 karakter giriniz.")
                .MaximumLength(500).WithMessage("En fazla 500 karakter giriniz.");

            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("Bu alan zorunludur.")
                .EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Bu alan zorunludur.")
                .MinimumLength(3).WithMessage("En az 3 karakter giriniz.")
                .MaximumLength(30).WithMessage("En fazla 30 karakter giriniz.");

            RuleFor(x => x.Adress)
               .NotEmpty().WithMessage("Bu alan zorunludur.")
               .MinimumLength(3).WithMessage("En az 3 karakter giriniz.")
               .MaximumLength(150).WithMessage("En fazla 150 karakter giriniz.");

        }
    }
}
