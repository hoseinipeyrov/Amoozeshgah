using Amoozeshgah.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NationalCodeAttribute : ValidationAttribute
    {
        public NationalCodeAttribute(string errorMessage)
            : base()
        {
            ErrorMessage = errorMessage;
        }
        public override bool IsValid(object value)
        {
            return (value != null && IsValidNationalCode(value.ToString()));
        }
        public bool IsValidNationalCode(string nationalcode)
        {
            return nationalcode.IsValidNationalCode();
        }
    }
}
