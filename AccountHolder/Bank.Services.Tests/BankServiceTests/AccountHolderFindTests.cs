using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank.Services.Tests.BankServiceTests
{
    class AccountHolderFindTests
    {
        AccountHolderService accountHolderService = new AccountHolderService();
        [Test]
        public void FindByIdTest()
        {
            accountHolderService.FindById(6);
        }
        [Test]
        public void FindByNameTest()
        {
           var MatchingRecordsCount =  accountHolderService.FindByName("Ranjit");

            Console.WriteLine("No Of Records = " + MatchingRecordsCount.Count());
        }

    }
}
