using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antique_Shop.Models
{
    public interface IAccountRepository
    {
       
        Account Add(Account account);
        Account Update(Account account);
        Account Delete(int id);
    }
}
