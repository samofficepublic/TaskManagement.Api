using FluentValidation;
using FluentValidation.Validators;
using TaskManagement.Common.Enums;
using TaskManagement.Common.Extentions;
using TaskManagement.Data.EntityConfigs;
using TaskManagement.Entity.DomainModels;

namespace TaskManagement.Data.EntityValidation
{
    public class UserValidatetion:AbstractValidator<User>
    {
        public UserValidatetion()
        {
            RuleFor(x => x.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible);
            RuleFor(x => x.Password).MinimumLength(8).MaximumLength(300)
                .WithMessage(EnumValidationMessage.MaxLenght.ToDisplay());
        }
    }
}