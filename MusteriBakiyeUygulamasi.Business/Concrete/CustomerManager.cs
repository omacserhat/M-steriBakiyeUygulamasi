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
                AccountNumber = CreateAccountNumber(),
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
        public Customer Remove(string tckNo)
        {
            using (var _context = new MusteriBakiyeUygulamasiContext())
            {
                var customerAccount = _context.CustomerAccount.SingleOrDefault(x => x.TckNo == tckNo);
                _context.CustomerAccount.Remove(customerAccount);
                _context.SaveChanges();
            }
            using (var _context = new MusteriBakiyeUygulamasiContext())
            {
                var customer = _context.Customer.SingleOrDefault(x=>x.TckNo == tckNo);
                if (tckNo is null)
                    throw new InvalidOperationException("Silinecek müşteri bulunamadı.");
                _context.Customer.Remove(customer);
                _context.SaveChanges();
                return customer;
            }
        }
        private string CreateAccountNumber(int length = 8)
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
