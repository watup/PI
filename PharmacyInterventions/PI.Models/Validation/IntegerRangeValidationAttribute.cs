using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PI.Models.Validation
{
    public class IntegerRangeValidationAttribute : ValidationAttribute
    {

        public IntegerRangeValidationAttribute(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int)
            {
                var converted = Convert.ToInt32(value);
                if(converted >= MinValue && converted <= MaxValue)
                {
                    return null;
                }

                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }

            return null;
        }
    }
}