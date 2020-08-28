using Bank.DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank.Services.Tests.BankServiceTests
{
    [TestFixture]
    class AccountHolderAddTests
    {
        AccountHolderService accountHolderService = new AccountHolderService();
        AccountHolder accountHolder;
        AccountholderDA dataAccess = new AccountholderDA();
        AcctHolderDbContext dbContext = new AcctHolderDbContext();


        [Test]
        // 1 .OKCase
        public void WhenCompleteObjectAddedThenTrue()
        {
            AccountHolder accountHolder = CreateAccountHolder();
            var countBeforeAdd = dbContext.AccountHolders.Count();
            accountHolderService.Add(accountHolder);
            var countAfterAdd = dbContext.AccountHolders.Count();
            Assert.That(countAfterAdd, Is.GreaterThan(countBeforeAdd));

        }
        private AccountHolder CreateAccountHolder()
        {
            accountHolder = new AccountHolder();
            accountHolder.Id = dataAccess.GetNextId();
            accountHolder.Name = "Abcd";
            accountHolder.Address = "Pune";
            accountHolder.BirthDate = new DateTime(2000, 01, 01);
            accountHolder.AnniversaryDate = new DateTime(2001, 01, 01);
            accountHolder.ContactNo = "1234567891";
            return accountHolder;
        }

        //2.If accountHolder object is null

        [Test]
        public void WhenAccountHolderNullThenAddThrowsArgumentNullException()
        {
            AccountHolder acctHolder = null;
            Assert.Throws<ArgumentNullException>(() => accountHolderService.Add(acctHolder));
        }

        [Test]
        public void WhenAccountHolderNullThenValidateThrowsArgumentNullException()
        {
            AccountHolder acctHolder = null;
            Assert.Throws<ArgumentNullException>(() => accountHolderService.Validate(acctHolder));
        }

        [Test]
        // 4 .Adding with same Id
        public void WhenInsertingExistingIdThenAddThrowsDbUpdateException()
        {
            AccountHolder accountHolder = CreateAccountHolder();
            accountHolder.Id = 8;
            accountHolderService.Add(accountHolder);
            Assert.Throws<Microsoft.EntityFrameworkCore.DbUpdateException>(() => accountHolderService.Add(accountHolder));
        }
        [Test]
        // 5 .Adding with empty field
        public void WhenAddressIsNullThenAddingFails()
        {
            AccountHolder accountHolder = CreateAccountHolder();
            accountHolder.Id = dataAccess.GetNextId();
            accountHolder.ContactNo = "1234567892";
            accountHolder.Address = null;
            Assert.Throws<Bank.Services.ValidationException>(() => accountHolderService.Add(accountHolder));


        }
        //6.Adding mobile number which already exists
        [Test]
        public void WhenMobileNoAlreadyExistThenValidationExceptionThrows()
        {
            AccountHolder accountHolder = CreateAccountHolder();
            accountHolder.ContactNo = "1234567890";
            Assert.Throws<Bank.Services.ValidationException>(() => accountHolderService.Add(accountHolder));
        }
        //7.Adding BirthDate Null
        [Test]
        public void WhenBirthDateIsInFutureThenValidationExceptionThrows()
        {
            AccountHolder accountHolder = CreateAccountHolder();
            accountHolder.Id = dataAccess.GetNextId();
            accountHolder.BirthDate = DateTime.Now.AddDays(1);
            accountHolder.ContactNo = "7744774433";
            Assert.Throws<Bank.Services.ValidationException>(() => accountHolderService.Add(accountHolder));
        }
        [Test]
        public void WhenAnniversaryDateIsNullThrowsValidationException()
        {
            AccountHolder accountHolder = CreateAccountHolder();
            accountHolder.Id = dataAccess.GetNextId();
            accountHolder.ContactNo = "7744774432";
            accountHolder.AnniversaryDate = null;
            var countAfterAdd = dbContext.AccountHolders.Count();
            Assert.Throws<Bank.Services.ValidationException>(() => accountHolderService.Add(accountHolder));
        }
    }
}
