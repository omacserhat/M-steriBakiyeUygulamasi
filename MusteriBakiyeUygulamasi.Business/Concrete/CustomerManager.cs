using MusteriBakiyeUygulamasi.Business.Abstract;
using MusteriBakiyeUygulamasi.DB.Entities;
using MusteriBakiyeUygulamasi.DB.Entities.MusteriBakiyeUygulamasiDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriBakiyeUygulamasi.Business.Concrete
{
    public class CustomerManager : ICustomer
    {
        public Customer Add(string name, string surname, string tckNo, string birthday)
        {
            var customer = new Customer()
            {
                Name = name,
                Surname = surname,
                TckNo = tckNo,
                Birthday = birthday
            };
            var account = new CustomerAccount()
            {
                AccountNumber = CreateAccountnumber(),
                Balance = 0,
                TckNo = tckNo
            };

            using (var _context = new MusteriBakiyeUygulamasiContext())
            {
                _context.Customer.Add(customer);

                _context.CustomerAccount.Add(account);
                _context.SaveChanges();
            }
            return customer;
        }

        public List<Customer> GetAll()
        {
            using (var _context = new MusteriBakiyeUygulamasiContext())
            {
                var customers = _context.Customer.ToList();
                return customers;
            }
        }


        private string CreateAccountnumber(int length = 8)
        {
            const string valid = "1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}
