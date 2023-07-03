using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalTourProject.DtoLayer.DTOs.AppUserDTO;

namespace TraversalTourProject.BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Adınızı boş bırakmayınız");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyadınızı boş bırakmayınız");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adınızı boş bırakmayınız");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir email adresi giriniz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifrenizi Giriniz");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifrenizi Tekrar Giriniz");
            RuleFor(x => x.UserName).MinimumLength(4).WithMessage("Kullanıcı Adınız için en az 4 karakter girmelisiniz");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("Kullanıcı Adınız için en fazla 20 karakter girmelisiniz");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Girmiş olduğunuz şifreler eşleşmiyor");
        }
    }
}
