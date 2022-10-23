using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriBakiyeUygulamasi.Business.Abstract
{
    public interface ICustomerAccount
    {
        decimal GetBalance(string tckNo);
        string AddBalance(string tckNo, string balance);
        string RemoveBalance(string tckNo, string balance);
    }
}
