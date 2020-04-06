using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TaskManagement.Common.Enums;
using TaskManagement.Common.Extentions;
using TaskManagement.Entity.DomainModels;

namespace TaskManagement.Data.EntityValidation
{
   public class AccessValidation:AbstractValidator<Access>
    {
        public AccessValidation()
        {
            RuleFor(x => x.AccessName).MaximumLength(100).WithMessage(EnumValidationMessage.MaxLenght.ToDisplay());
            RuleFor(x => x.AccessName).NotEmpty().WithMessage(EnumValidationMessage.IsRequire.ToDisplay());
            RuleFor(x => x.AccessComponent).NotEmpty().WithMessage(EnumValidationMessage.IsRequire.ToDisplay());
        }
    }
}
