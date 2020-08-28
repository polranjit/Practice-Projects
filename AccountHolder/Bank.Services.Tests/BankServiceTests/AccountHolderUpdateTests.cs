using Bank.DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Bank.Services.Tests.BankServiceTests
{
    class AccountHolderUpdateTests

    {
        AccountHolderService accountHolderService = new AccountHolderService();
        AccountHolder accountHolder;
        AccountholderDA dataAccess = new AccountholderDA();
        AcctHolderDbContext dbContext = new AcctHolderDbContext();

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
        //1.All Ok Case
        [Test]
        public void WhenUpdatingWithCompleteObjectThenTestSuccess()
        {
            var accountToUpdate = dbContext.AccountHolders.Where(a => a.Id == 4).FirstOrDefault();
            accountToUpdate.AnniversaryDate = new DateTime(2010, 11, 30);
            accountHolderService.Update(accountToUpdate);
        }
    
        //.passing one field empty
        [Test]
        public void WhenAddressIsNullThenUpdate()
        {
            var accountToUpdate = dbContext.AccountHolders.Where(a => a.Id == 4).FirstOrDefault();
            accountToUpdate.Address =" ";
         
            Assert.Throws<Bank.Services.ValidationException>(() => accountHolderService.Update(accountToUpdate));
        }
        //.passing object which does not exist
        [Test]
        public void WhenAccountHolderNotExistThen()
        {
            var accountToUpdate = dbContext.AccountHolders.Where(a => a.Id == 40).FirstOrDefault();
           // accountToUpdate.Address = "Nashik";
            Assert.Throws<ValidationException>(() => accountHolderService.Update(accountToUpdate));
        }
       
    }
}
