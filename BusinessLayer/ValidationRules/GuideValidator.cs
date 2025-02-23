using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen rehber adını ekleyiniz..!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen rehber açıklamasını ekleyiniz..!");
            RuleFor(x => x.Description).MaximumLength(30).WithMessage("Lütfen 30 karakterden daha kısa bir açıklama ekleyiniz..! ");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Lütfen 10 karakterden daha uzun  bir açıklama ekleyiniz..! ");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen rehber görselini ekleyiniz..!");

        }
    }
}
