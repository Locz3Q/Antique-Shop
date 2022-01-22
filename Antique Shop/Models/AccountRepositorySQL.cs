using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antique_Shop.Models
{
    public class AccountRepositorySQL : IAccountRepository, IPayment
    {
        private readonly ApplicationDbContext dbContext;

        public AccountRepositorySQL(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Account Add(Account account)
        {
            dbContext.Accounts.Add(account);
            dbContext.SaveChanges();
            return account;
        }

        public Account AddSaldo(Account account, float number)
        {
            account.Saldo += number;
            this.Update(account);
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

        public Account MoveSaldo(Account accountBuyer, Account accountSeller, float number)
        {
            accountBuyer.Saldo -= number;
            accountSeller.Saldo += number;
            this.Update(accountBuyer);
            this.Update(accountSeller);
            return accountBuyer;
        }

        public Account SubtractSaldo(Account account, float number)
        {
            account.Saldo -= number;
            this.Update(account);
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
