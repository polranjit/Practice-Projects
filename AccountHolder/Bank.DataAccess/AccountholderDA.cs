using System;
using System.Linq;
namespace Bank.DataAccess
{
    public class AccountholderDA
    {
        AcctHolderDbContext dataContext = new AcctHolderDbContext();

        //Insert
        public void Add(AccountHolder accountHolder)
        {
            if (accountHolder == null) throw new ArgumentNullException(nameof(accountHolder));
            dataContext.AccountHolders.Add(accountHolder);
            dataContext.SaveChanges();
        }

        //Find By Id
        public AccountHolder FindById(int id)
        {
           
                return dataContext.AccountHolders.Find(id);
        
        }
        //Find By Name
        public IQueryable<AccountHolder> FindByName(string name)
        {
            return dataContext.AccountHolders.Where(a => a.Name == name);
        }
      
        //Update
        public void Update(AccountHolder accountHolder)
        {
            dataContext.AccountHolders.Update(accountHolder);
            dataContext.SaveChanges();
        }

        //Delete Acct
        public void Delete(AccountHolder ac)
        {
            dataContext.AccountHolders.Remove(ac);
            dataContext.SaveChanges();
        }

        public int GetNextId()
        { 
         return dataContext.AccountHolders.Select(o => o.Id).Max() + 1;
        }

        public IQueryable<AccountHolder> GetAllAccountHolders()
        {
            return dataContext.AccountHolders;
        }
        public bool IsAccountPresent(int id)
        {
           bool IsIDPresent = false;
            return IsIDPresent;
        }
    }
}
