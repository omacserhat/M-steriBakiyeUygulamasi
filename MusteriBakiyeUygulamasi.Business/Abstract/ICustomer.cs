using MusteriBakiyeUygulamasi.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriBakiyeUygulamasi.Business.Abstract
{
    public interface ICustomer
    {
        Customer Add(string name, string surname, string tckNo, string birthday);
        List<Customer> GetAll();
        Customer Remove(string tckNo);
    }
}
