using System;
using NUnit.Framework;
using Bank.DataAccess;
using System.Linq;

namespace Bank.DataAccess.Tests
{
    [TestFixture]
    public class AccountHolderTests
    {
        AccountholderDA accountHolderDataAccess = new AccountholderDA();

        private AccountHolder CreateAccountHolder()
        {
            AccountHolder accountHolder = new AccountHolder();
            accountHolder.Id = accountHolderDataAccess.GetNextId();
            accountHolder.Name = "Ranjit";
            accountHolder.Address = "Pune";
            accountHolder.BirthDate = new DateTime(2000, 01, 01);
            accountHolder.ContactNo = "1234567890";
            accountHolder.AnniversaryDate = new DateTime(2010, 01, 01);
            return accountHolder;
        }


        //Test Case for Insert
        [Test]
        public void WhenCompleteObjectThenAddSuccesses()
        {
            AcctHolderDbContext dbContext = new AcctHolderDbContext();
            var countBeforeAdd = dbContext.AccountHolders.Count();
            AccountHolder accountHolder = CreateAccountHolder();
            accountHolderDataAccess.Add(accountHolder);
            var countAfterAdd = dbContext.AccountHolders.Count();
            Assert.That(countAfterAdd, Is.GreaterThan(countBeforeAdd));

        }
        [Test]
        public void WhenAccountToInsertIsNullThenExceptionWillThrow()
        {
            AccountHolder accountHolder = null;
           
            Assert.Throws<System.ArgumentNullException>(() =>
            {
                accountHolderDataAccess.Add(accountHolder);
            });
        }
        [Test]
        public void WhenAccountToInsertIsPresentThenExceptionWillThrow()
        {
            AccountHolder accountHolder = CreateAccountHolder();
            accountHolder.Id = 1;
                       Assert.Throws<Microsoft.EntityFrameworkCore.DbUpdateException>(() =>
            {
                accountHolderDataAccess.Add(accountHolder);
            });
        }
        [Test]
        public void WhenNameIsNullThenAddFails()
        {
            AccountHolder accountHolder = CreateAccountHolder();
            accountHolder.Name = null;
           
            Assert.Throws<Microsoft.EntityFrameworkCore.DbUpdateException>(() =>
            {
                accountHolderDataAccess.Add(accountHolder);
            });
        }


        //Test Case for Update
        [Test]
        public void WhenAccountToUpdateIsPresentThenUpdateSuccesses()
        {
            AcctHolderDbContext dbContext = new AcctHolderDbContext();
            var accountToUpdate = dbContext.AccountHolders.Where(a => a.Id == 4).FirstOrDefault();
            accountToUpdate.AnniversaryDate = new DateTime(1992, 11, 30);
            accountHolderDataAccess.Update(accountToUpdate);
           // Assert.AreEqual((1992, 11, 30), dbContext.AccountHolders.Find(accountToUpdate.Id).AnniversaryDate);

           
        }
        [Test]
        public void WhenAccountToUpdateIsNotPresentThenUpdateFails()
        {
            AcctHolderDbContext dbContext = new AcctHolderDbContext();
            var accountToUpdate = dbContext.AccountHolders.Where(a => a.Id == 40).FirstOrDefault();
            accountToUpdate.AnniversaryDate = new DateTime(1992, 11, 30);
           
            Assert.Throws<System.NullReferenceException>(() =>
            {
                accountHolderDataAccess.Update(accountToUpdate);
            });

        }
        //Test Case for FindByID
        [Test]
        public void WhenAccountIdIsPresentThenFindByIdSuccesses()
        {
            accountHolderDataAccess.FindById(2);

        }
        [Test]
        public void WhenAccountIdIsNotPresentThenFindByIdSuccesses()
        {
            accountHolderDataAccess.FindById(2);

        }
        //Test Case for FindByName
        [Test]
        public void WhenAccountPresentWithNameThenFindByNameSuccesses()
        {
            accountHolderDataAccess.FindByName("Ranjit");
            
        }
        //Test Case for Delete
        [Test]
        public void WhenAccountToDeleteISPresentThenDetateSuccesses()
        {
            AccountHolder accountHolder = CreateAccountHolder();
            accountHolder.Id = 30;
            accountHolderDataAccess.Add(accountHolder);
            AcctHolderDbContext dbContext = new AcctHolderDbContext();
            var countBeforeDelete = dbContext.AccountHolders.Count();       
            accountHolderDataAccess.Delete(accountHolder);
            var countAfterDelete = dbContext.AccountHolders.Count();
            Assert.That(countBeforeDelete, Is.GreaterThan(countAfterDelete));
        }
        [Test]
        public void WhenAccountToDeleteISNotPresentThenDetateFails()
        {
            AccountHolder accountHolder = CreateAccountHolder();

            accountHolder.Id = 30;
            
            Assert.Throws<Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException>(() =>
            {
                accountHolderDataAccess.Delete(accountHolder);
            });
        }
    }
}
