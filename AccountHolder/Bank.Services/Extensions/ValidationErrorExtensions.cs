using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Services.Extensions
{
    public static class ValidationErrorExtensions
    {
        public static void AddToExceptionIfNotNull(this ValidationError error, ValidationException validationException) 
        {
            if (error != null)
                validationException.ValidationErrors.Add(error);
        }
    }
}
