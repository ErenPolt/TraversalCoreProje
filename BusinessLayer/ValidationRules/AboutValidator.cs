using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            //NotEmpty: Boş geçilemez anlamına gelir.
            //WithMessage: Kullanıcıya bilgi mesajıdır.
            //MinimumLength(): Girişi yapılan verinin en kısa karakter uzunluğunu kontrol eder. Parantezi içine değeri yazılır..
            //MaximumLength(): Girişi yapılan verinin en uzun karakter uzunluğunu kontrol eder. Parantezi içine değeri yazılır..

            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmını boş geçemezsiniz..!");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Lütfen en az 50 karakterlik açıklama bilgisi giriniz..!");
            RuleFor(x => x.Description).MaximumLength(1500).WithMessage("Lütfen açıklamayı kısaltın..!");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Lütfen görsel seçin..!");
        }
    }
}
