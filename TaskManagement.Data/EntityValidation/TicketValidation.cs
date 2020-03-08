using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TaskManagement.Common.Enums;
using TaskManagement.Common.Extentions;
using TaskManagement.Entity.DomainModels;

namespace TaskManagement.Data.EntityValidation
{
 public   class TicketValidation:AbstractValidator<Ticket>
    {
        public TicketValidation()
        {
            RuleFor(x => x.Subject).MinimumLength(5).MaximumLength(250)
                .WithMessage(EnumValidationMessage.MaxLenght.ToDisplay());
            RuleFor(x => x.Description).MinimumLength(20).MaximumLength(4000)
                .WithMessage(EnumValidationMessage.MaxLenght.ToDisplay());
        }
    }
}
