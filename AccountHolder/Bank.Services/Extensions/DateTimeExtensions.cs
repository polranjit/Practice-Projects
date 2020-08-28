using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Services.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsInFuture(DateTime date)
        {
            return (date > DateTime.Now);
        }
        public static bool IsInFuture(DateTime? date)
        {
            return (date > DateTime.Now);
        }
    }
}
