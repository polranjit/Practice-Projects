using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Services
{
    public class ValidationException : ApplicationException
    {
        public List<ValidationError> ValidationErrors { get; set; }
        public ValidationException()
        {
            ValidationErrors = new List<ValidationError>();
        }
    }
}
