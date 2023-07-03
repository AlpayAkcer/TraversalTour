using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalTourProject.EntityLayer.Concrete;

namespace TraversalTourProject.BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Rehber Adını Boş Geçmeyiniz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Rehber Soyadını Boş Geçmeyiniz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-mail adresini Boş Geçmeyiniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Rehber Soyadını Boş Geçmeyiniz");
            RuleFor(x => x.Name).MinimumLength(8).WithMessage("8 Karakterden daha fazla veri giriniz");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("20 Karakterden daha az veri giriniz");
        }
    }
}
