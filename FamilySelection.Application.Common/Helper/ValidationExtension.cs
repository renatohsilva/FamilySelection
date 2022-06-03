using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Application.Common.Helper
{
    public static class ValidationExtension
    {
        public static IEnumerable<string> ToListValidationFailureString(this IEnumerable<ValidationFailure> Errors)
        {
            if (Errors != null && Errors.Any())
            {
                return Errors.Select(item => item.ErrorMessage);
            }
            return new List<string>();
        }
    }
}
