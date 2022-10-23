using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusteriBakiyeUygulamasi.Business.Abstract;
using MusteriBakiyeUygulamasi.DB.Entities;

namespace MüsteriBakiyeUygulamasi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customer;

        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }
        [HttpGet]
        public List<Customer> GetAll()
        {
            return _customer.GetAll();
        }
        [HttpPost]
        public IActionResult Add(string name, string surname, string tckNo, string birthday)
        {
            var result = _customer.Add(name, surname, tckNo, birthday);
            return Ok(result);
        }
    }
}
