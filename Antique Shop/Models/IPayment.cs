using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antique_Shop.Models
{
    public interface IPayment
    {
        Account AddSaldo(Account account, float number);
        Account SubtractSaldo(Account account, float number);
        Account MoveSaldo(Account accountBuyer, Account accountSeller, float number);
    }
}
