using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bank.DataAccess;
using Bank.Services;

namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountHolderController : ControllerBase
    {
       
        AccountHolderService service = new AccountHolderService();
        
        [HttpGet]
        public IQueryable<AccountHolder> GetAccountHolders()
        {
            return service.FindByName("Ranjit");
        }

    }
}