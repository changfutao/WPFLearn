using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFLearn.FormValidate.ValidateRules
{
    public class MyErrorValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string str && string.IsNullOrEmpty(str))
            {
                return new ValidationResult(false, "值不能为空");
            }
            return ValidationResult.ValidResult;
        }
    }
}
