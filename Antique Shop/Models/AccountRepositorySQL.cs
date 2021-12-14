using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antique_Shop.Models
{
    public class AccountRepositorySQL : IAccountRepository
    {
        private readonly ApplicationDbContext dbContext;

        public AccountRepositorySQL(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Account Add(Account account)
        {
            account.Saldo = 0;
            dbContext.Accounts.Add(account);
            dbContext.SaveChanges();
            return account;
        }

        public Account Delete(int id)
        {
            Account account = dbContext.Accounts.Find(id);
            if (account != null)
            {   
                dbContext.Remove(account);
                dbContext.SaveChanges();
            }
            return account;
        }

        public Account Update(Account accountUpdate)
        {
            var account = dbContext.Accounts.Attach(accountUpdate);
            account.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return accountUpdate;
        }
    }
}
