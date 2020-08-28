using System;
using System.Linq;
using Bank.DataAccess;
using Bank.Services.Extensions;

namespace Bank.Services
{
    public class AccountHolderService
    {
        AcctHolderDbContext DbContext = new AcctHolderDbContext();
        ValidationException validationException = new ValidationException();


        public void Validate(AccountHolder accountHolder)
        {
            if (accountHolder == null) throw new ArgumentNullException(nameof(accountHolder));

            var validationException = new ValidationException();

            ValidateMobileNo(accountHolder)
                .AddToExceptionIfNotNull(validationException);
            ValidateNameNotEmpty(accountHolder)
                .AddToExceptionIfNotNull(validationException);

            AddErrorInException(validationException, ValidateMobileNo, accountHolder);
            AddErrorInException(validationException, ValidateUniqueMobileNo, accountHolder);
            AddErrorInException(validationException, ValidateNameNotEmpty, accountHolder);
            AddErrorInException(validationException, ValidateAddressNotEmpty, accountHolder);
            AddErrorInException(validationException, ValidateBirthDate, accountHolder);
            AddErrorInException(validationException, ValidateAnniversaeyDate, accountHolder);
            AddErrorInException(validationException, ValidateAnniversaryDateNotNull, accountHolder);
            if (validationException.ValidationErrors.Count > 0)
            {
                throw validationException;
            }
        }
        private void AddErrorInException(ValidationException validationException,
                                        Func<AccountHolder, ValidationError> validationMethod,
                                        AccountHolder accountHolder)
        {
            var validateError = validationMethod(accountHolder);
            if (validateError != null)
                validationException.ValidationErrors.Add(validateError);
        }
        public void AccountHolderCheck(AccountHolder accountHolder)
        {
            if (IsAccountPresent(accountHolder) != null)

            {
                validationException.ValidationErrors.Add(IsAccountPresent(accountHolder));
            }
            if (validationException.ValidationErrors.Count > 0)
            {
                throw validationException;
            }

        }
        private ValidationError IsAccountPresent(AccountHolder accountHolder)
        {
            if (!(DbContext.AccountHolders.Contains(accountHolder)))
            {
                ValidationError error = new ValidationError("AccountHolder is not present", "AccountHolder");
                return error;
            }
            return null;
        }
        private ValidationError ValidateMobileNo(AccountHolder accountHolder)
        {
            ValidateNullMobileNo(accountHolder.ContactNo);
            ValidateMaxLengthMobileNo(accountHolder.ContactNo, 10);
            return null;
        }
        private ValidationError ValidateNullMobileNo(string contactNo)
        {
            if (string.IsNullOrWhiteSpace(contactNo))
            {
                ValidationError error = new ValidationError("Mobile No should not be empty.", "ContactNo");
                return error;
            }
            return null;
        }
        private ValidationError ValidateMaxLengthMobileNo(string contactNo, int maxLength)
        {
            if (contactNo.Length != maxLength)
            {
                ValidationError error = new ValidationError("Invalid MobileNo.", "ContactNo");
                return error;

            }
            return null;
        }
        private ValidationError ValidateUniqueMobileNo(AccountHolder accountHolder)
        {

            //ValidationError error = new ValidationError("Mobile number already exists", "Contact");
            var matchingRecord = DbContext.AccountHolders.Where(h => h.ContactNo == accountHolder.ContactNo).Where(h => h.Id != accountHolder.Id).Count();

            if (matchingRecord > 0)
            {
                //return error;
                return new ValidationError("Mobile number already exists", "Contact");
            }
            return null;
        }
        private ValidationError ValidateNameNotEmpty(AccountHolder accountHolder)
        {
            if (string.IsNullOrWhiteSpace(accountHolder.Name))
            {
                ValidationError error = new ValidationError("Name should not be empty.", "Name");
                return error;
            }
            return null;
        }
        private ValidationError ValidateAddressNotEmpty(AccountHolder accountHolder)
        {
            if (string.IsNullOrWhiteSpace(accountHolder.Address))
            {
                ValidationError error = new ValidationError("Address should not be empty.", "Address");
                return error;
            }
            return null;
        }
        private ValidationError ValidateBirthDate(AccountHolder accountHolder)
        {

            if (DateTimeExtensions.IsInFuture(accountHolder.BirthDate))
            {
                ValidationError error = new ValidationError("BirthDate should not be in future.", "Birthdate");
                return error;
            }
            return null;
        }
        private ValidationError ValidateAnniversaeyDate(AccountHolder accountHolder)
        {

            if (DateTimeExtensions.IsInFuture(accountHolder.AnniversaryDate))
            {
                ValidationError error = new ValidationError("Anniversary Date should not be in future.", "AnniversaryDate");
                return error;
            }
            return null;
        }
        private ValidationError ValidateAnniversaryDateNotNull(AccountHolder accountHolder)
        {
            if (accountHolder.AnniversaryDate == null)
            {
                ValidationError error = new ValidationError("AnniversaryDate shoild not be null.", "AnniversaryDate");
                return error;
            }
            return null;
        }
        AccountholderDA accountHolderDA = new AccountholderDA();

        public AccountHolder Add(AccountHolder acctHolder)
        {
            Validate(acctHolder);
            accountHolderDA.Add(acctHolder);
            return acctHolder;
        }

        public AccountHolder Update(AccountHolder accountHolder)
        {
            AccountHolderCheck(accountHolder);
            Console.WriteLine("Account Found");
            Validate(accountHolder);
            accountHolderDA.Update(accountHolder);
            return accountHolder;
        }
        public void Delete(AccountHolder accountHolder)
        {
            AccountHolderCheck(accountHolder);
            accountHolderDA.Delete(accountHolder);

        }

        public AccountHolder FindById(int id)
        {
            return accountHolderDA.FindById(id);
        }
        public IQueryable<AccountHolder> FindByName(string name)
        {
            return accountHolderDA.FindByName(name);
        }
        public IQueryable<AccountHolder> GetAllAccountHolders()
        {
            return accountHolderDA.GetAllAccountHolders();
        }
    }
}
