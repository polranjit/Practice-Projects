using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Services
{
    public class ValidationError
    {
        public string ErrorMessage { get; set; }
        public string Field { get; set; }

        public ValidationError( string errorMsg, string field)
        {
            this.ErrorMessage = errorMsg;
            this.Field = field;
        }
    }
}
