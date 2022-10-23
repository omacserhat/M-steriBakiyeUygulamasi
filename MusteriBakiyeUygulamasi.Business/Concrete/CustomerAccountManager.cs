using MusteriBakiyeUygulamasi.Business.Abstract;
using MusteriBakiyeUygulamasi.DB.Entities.MusteriBakiyeUygulamasiDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriBakiyeUygulamasi.Business.Concrete
{
    public class CustomerAccountManager : ICustomerAccount
    {
        public string AddBalance(string tckNo, string balance = "0")
        {
            using (var _context = new MusteriBakiyeUygulamasiContext())
            {
                var result = _context.CustomerAccount.Where(x => x.TckNo == tckNo).FirstOrDefault();
                result.Balance += Convert.ToDecimal(balance);
                _context.CustomerAccount.Update(result);
                _context.SaveChanges();
            }
            return "Bakiye Eklendi.";
        }

        public decimal GetBalance(string tckNo)
        {
            decimal balance = 0;
            using (var _context = new MusteriBakiyeUygulamasiContext())
            {
                var result = _context.CustomerAccount.Where(x => x.TckNo == tckNo).FirstOrDefault();
                if (result?.Balance != 0)
                {
                    balance = (decimal)result.Balance;
                }
            }
            return balance;
        }

        public string RemoveBalance(string tckNo, string balance = "0")
        {
            using (var _context = new MusteriBakiyeUygulamasiContext())
            {
                var result = _context.CustomerAccount.Where(x => x.TckNo == tckNo).FirstOrDefault();
                result.Balance -= Convert.ToDecimal(balance);
                _context.CustomerAccount.Update(result);
                _context.SaveChanges();
            }
            return "Bakiye çıkarıldı.";
        }
    }
}
