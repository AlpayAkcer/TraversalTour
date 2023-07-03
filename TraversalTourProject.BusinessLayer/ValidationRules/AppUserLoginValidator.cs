using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalTourProject.DtoLayer.DTOs.AppUserDTO;

namespace TraversalTourProject.BusinessLayer.ValidationRules
{
    public class AppUserLoginValidator : AbstractValidator<AppUserLogInDto>
    {
        public AppUserLoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adınızı boş bırakmayınız");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifrenizi Giriniz");
            RuleFor(x => x.Username).MinimumLength(4).WithMessage("Kullanıcı Adınız için en az 4 karakter girmelisiniz");
            RuleFor(x => x.Username).MaximumLength(20).WithMessage("Kullanıcı Adınız için en fazla 20 karakter girmelisiniz");
        }
    }
}
