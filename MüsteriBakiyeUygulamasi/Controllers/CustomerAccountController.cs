using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusteriBakiyeUygulamasi.Business.Abstract;

namespace MüsteriBakiyeUygulamasi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAccountController : ControllerBase
    {
        private ICustomerAccount _customerAccount;
        public CustomerAccountController(ICustomerAccount customerAccount)
        {
            _customerAccount = customerAccount;
        }
        [HttpDelete]
        public string RemoveBalance(string tckNo, string balance)
        {
            return _customerAccount.RemoveBalance(tckNo, balance);
        }
        [HttpPost]
        public string AddBalance(string tckNo, string balance)
        {
            return _customerAccount.AddBalance(tckNo, balance);
        }
        [HttpGet]
        public decimal GetBalance(string tckNo)
        {
            return _customerAccount.GetBalance(tckNo);
        }
    }
}
