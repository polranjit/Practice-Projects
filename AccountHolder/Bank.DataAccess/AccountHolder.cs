using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.DataAccess
{
    public class AccountHolder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string ContactNo { get; set; }
        public DateTime? AnniversaryDate { get; set; }

    }
}
