using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManagement.Common.Enums
{
    public enum EnumValidationMessage
    {
        [Display(Name = "اطلاعات اجباری")]
        IsRequire,
        [Display(Name = "تعداد کاراکتر غیر مجاز")]
        MaxLenght
    }
    public enum DisplayProperty
    {
        Description,
        GroupName,
        Name,
        Prompt,
        ShortName,
        Order
    }
}
