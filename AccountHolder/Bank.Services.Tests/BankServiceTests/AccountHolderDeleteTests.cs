using Bank.DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank.Services.Tests.BankServiceTests
{
    class AccountHolderDeleteTests
    {
        AccountHolderService accountHolderService;
        AcctHolderDbContext dbContext;

        [OneTimeSetUp]
        public void ClassInit()
        {
            accountHolderService = new AccountHolderService();
            dbContext = new AcctHolderDbContext();
        }

        //1.When account exists
        [Test]
        public void WhenAccountExisDeleteSuccesses()
        {
            var countBeforeDelete = dbContext.AccountHolders.Count();
            var acctToDelete = dbContext.AccountHolders.Where(h => h.Id == 11).FirstOrDefault();
            accountHolderService.Delete(acctToDelete);
            var countAfterDelete = dbContext.AccountHolders.Count();
            Assert.That(countAfterDelete, Is.LessThan(countBeforeDelete));
        }
        //2.When Account does not exist
        [Test]
        public void WhenAccountNotExistThenTestFail()
        {
            var acctToDelete = dbContext.AccountHolders.Where(h => h.Id == 11).FirstOrDefault();
            Assert.Throws<ValidationException>(() => accountHolderService.Update(acctToDelete));
        }
    }
}
