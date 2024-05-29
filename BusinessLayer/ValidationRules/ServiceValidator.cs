using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ServiceValidator : AbstractValidator<Service>
    {
        public ServiceValidator()
        {
            RuleFor(x=>x.Title)
                .NotEmpty().WithMessage("Bu alan zorunludur")
                .MaximumLength(100).WithMessage("En fazla 100 karakter giriniz.");
        }
    }
}
