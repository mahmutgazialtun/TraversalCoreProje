﻿using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUs
{
    public class SendContactUsValidator: AbstractValidator<SendMessageDto>
    {
        public SendContactUsValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x => x.Mail).MinimumLength(5).WithMessage("Mail alana en az 5 karakter veri girişi yapmalısınız");
            RuleFor(x => x.Mail).MaximumLength(5).WithMessage("Mail alana en fazla 100 karakter veri girişi yapmalısınız");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Konu alana en az 5 karakter veri girişi yapmalısınız");
            RuleFor(x => x.Subject).MaximumLength(5).WithMessage("Konu alana en fazla 100 karakter veri girişi yapmalısınız");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj alanı boş geçilemez");
        }
    }
}
