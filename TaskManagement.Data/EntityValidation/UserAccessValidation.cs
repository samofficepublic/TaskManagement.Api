using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TaskManagement.Common.Enums;
using TaskManagement.Common.Extentions;
using TaskManagement.Entity.DomainModels;

namespace TaskManagement.Data.EntityValidation
{
    public class UserAccessValidation:AbstractValidator<UserAccess>
    {
        public UserAccessValidation()
        {
            RuleFor(x => x.AccessId).NotEmpty().WithMessage(EnumValidationMessage.IsRequire.ToDisplay());
            RuleFor(x => x.UserId).NotEmpty().WithMessage(EnumValidationMessage.IsRequire.ToDisplay());
        }
    }
}
