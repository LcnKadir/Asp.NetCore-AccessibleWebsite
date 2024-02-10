using CoreLayer.DTOs;
using CoreLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ValidationRules
{
    internal class AppUserValidatior: AbstractValidator<UserRegisterDto>
    {
        public AppUserValidatior() 
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("KullanıcıAdı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrar alanı boş geçilemez");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Cinsiyet alanı boş geçilemez");

            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("lütfen en az 3 karakter veri girişi yapınız");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("lütfen en fazla 20 karakter veri girişi yapınız");
            RuleFor(x => x.Password).Equal(c => c.ConfirmPassword).WithMessage("şifreler birbiriyle uyuşmuyor");


        }
    }
}
