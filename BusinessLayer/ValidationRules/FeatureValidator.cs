using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class FeatureValidator : AbstractValidator<Feature>
    {
        public FeatureValidator()
        {
            RuleFor(x => x.Header)
                .NotEmpty().WithMessage("Bu alan zorunludur")
                .MaximumLength(100).WithMessage("En fazla 100 kadarkter giriniz");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Bu alan zorunludur")
                .MaximumLength(100).WithMessage("En fazla 100 kadarkter giriniz");

            
        }
    }
}
