using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kursach
{
    public static class Validations
    {
        public static List<ValidationResult> validationResult;
        public static ValidationContext validationContext;
        public static bool TryValidate(string query, ValidationContext vCntxt, string propName)
        {
            validationContext = vCntxt;
            validationResult = new List<ValidationResult>();
            vCntxt.MemberName = propName;
            if (Validator.TryValidateProperty(query, vCntxt, validationResult))
            {
                //(validationContext.ObjectInstance as LoginPageViewModel).ErrorMessage = string.Empty;
                return false;
            }
            else
            {
                //(validationContext.ObjectInstance as LoginPageViewModel).ErrorMessage = validationResult.ToArray()[0].ErrorMessage;
                return true;
            }
        }
    }
}
