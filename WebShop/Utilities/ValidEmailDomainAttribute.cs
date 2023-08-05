using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Utilities
{
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        private string _allowedDomain;

        public ValidEmailDomainAttribute(string allowedDomain)
        {
            _allowedDomain = allowedDomain;
        }

        public override bool IsValid(object value)
        {
            var email = value.ToString();
            var stringArray = email.Split("@");
            var domain = stringArray.Last();
            var isValid = domain.ToUpper().Equals(_allowedDomain.ToUpper());

            return isValid;
        }
    }
}
