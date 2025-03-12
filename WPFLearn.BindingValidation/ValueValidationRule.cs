using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFLearn.BindingValidation
{
    /// <summary>
    /// 验证规则
    /// </summary>
    public class ValueValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value != null && value.ToString() == "333")
            {
                return new ValidationResult(false, "属性值有问题");
            }
            return new ValidationResult(true, "");
        }
    }
}
