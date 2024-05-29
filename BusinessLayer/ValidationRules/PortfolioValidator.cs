using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator : AbstractValidator<Portfolio>
    {
        public PortfolioValidator() 
        {
            RuleFor(x=>x.ProjectName).NotEmpty().WithMessage("Proje adı alanı zorunludur");
            RuleFor(x => x.ProjectName).MinimumLength(2).WithMessage("Proje Adı 2 karakterden kısa olamaz");
            RuleFor(x => x.ProjectName).MaximumLength(100).WithMessage("Proje Adı 100 karakterden uzun olamaz");


            RuleFor(x => x.CompletionValue).NotNull().WithMessage("Lütfen projenin yüzde kaçının bittiğini giriniz");
            RuleFor(x => x.CompletionValue).NotEmpty().WithMessage("Lütfen projenin yüzde kaçının bittiğini giriniz");
            RuleFor(x => x.CompletionValue).Must(x => x.ToString().Length >=1).WithMessage("Lütfen geçerli bir sayı giriniz");
            RuleFor(x => x.CompletionValue).GreaterThan(0).WithMessage("Lütfen 0-100 arasında bir değer giriniz.");
            RuleFor(x => x.CompletionValue).LessThan(100).WithMessage("Lütfen 0-100 arasında bir değer giriniz.");


            RuleFor(x => x.Price).NotEmpty().WithMessage("Ücret alanı zorunludur");
        }
    }
}
