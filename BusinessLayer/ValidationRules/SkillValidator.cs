using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SkillValidator : AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen yetenek başlığı giriniz");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Yetenek başlığı 100 karakterden kısa olmalı");


            RuleFor(x => x.Value).Must(x => Convert.ToInt16(x) >= 0).WithMessage("Sayı 0'dan büyük olmalı");
            RuleFor(x => x.Value).Must(x => Convert.ToInt16(x) <= 100).WithMessage("Sayı 100'den küçük olmalı");
        }
    }
}
