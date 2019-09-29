using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Avassy.NetCore.Global.Attributes
{
    public class EmailAddressExtendedAttribute : ValidationAttribute
    {
        public EmailAddressExtendedAttribute()
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return !Regex.IsMatch((string)value, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$") ? new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName)) : null;
        }
    }
}
