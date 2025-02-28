using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator: AbstractValidator<AppUserRegisterDTOs>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Adınızı Giriniz..!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen Soyadınızı Giriniz..!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Lütfen E-Posta Giriniz..!");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Lütfen Kullanıcı Adınızı Giriniz..!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen Şifrenizi Giriniz..!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Lütfen Şifre Tekrarını Giriniz..!");

            RuleFor(x => x.Username).MinimumLength(5).WithMessage("En az 5 Karakter..!");
            RuleFor(x => x.Username).MaximumLength(20).WithMessage("En Fazla 20 Karakter");

            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Şifreler birbiriyle uyuşmuyor.");
            
            
        }
    }
}
