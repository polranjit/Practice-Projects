using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Bank.Services;
using Bank.DataAccess;

namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountHolderController : ControllerBase
    {
        AccountHolderService service = new AccountHolderService();
        AcctHolderDbContext dbContext = new AcctHolderDbContext();

        [HttpGet]
        public IQueryable GetAllAccountHolders()
        {
            return service.GetAllAccountHolders();
        }
        [HttpGet("{name}")]
        public IQueryable GetAccountHoldersByName(string name)
        {
            return service.FindByName(name);
        }
        [HttpGet("{id:int}")]
        public AccountHolder GetAccountHoldersById(int id)
        {
            return service.FindById(id);
        }

        [HttpPost]
        public AccountHolder Insert(AccountHolder accountHolder)
        {
            AccountholderDA dataAccess = new AccountholderDA();
            accountHolder.Id = dataAccess.GetNextId();
            return service.Add(accountHolder);

        }
        [HttpPut]
        public AccountHolder Update(AccountHolder accountHolder)
        {
            return service.Update(accountHolder);
        }
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            var acctToDelete = dbContext.AccountHolders.Where(h => h.Id == id).FirstOrDefault();
            service.Delete(acctToDelete);

        }

    }
}