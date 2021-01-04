using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using RegistrationOfMember.Entities.Concrete;

namespace RegistrationOfMember.Business.ValidationRules.FluentValidation
{
    public class MemberValidator:AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(m => m.TcNo).Length(11).NotEmpty().WithMessage("11 haneli TC Kimlik numarası boş geçilemez");
            RuleFor(m => m.FirstName).NotEmpty().WithMessage("Ad kısmı boş geçilemez");
            RuleFor(m => m.LastName).NotEmpty().WithMessage("Soyad kısmı boş geçilemez");
            RuleFor(m => m.DateOfBirth).LessThan(DateTime.Now).WithMessage("Doğum tarihini yanlış girdiniz");
            RuleFor(m => m.Email).EmailAddress().WithMessage("Geçersiz Email adresi ");
        }
    }
}
