using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Добавить страницу которая доступна только администратору с возможностью менять роль
//пользователя, удалять существующих и добавлять новых пользователей.

namespace web_basics.data.Repositories
{
    public class Account
    {
        WebBasicsDBContext context;

        public Account(IConfiguration configuration)
        {
            this.context = new WebBasicsDBContext(configuration);
        }

        public IEnumerable<Entities.Account> Get()
        {
            var accounts = context.Accounts.ToList();
            return accounts;
        }
        public void Create(Entities.Account account)
        {
            context.Accounts.Add(account);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context.Accounts.Remove(context.Accounts.FirstOrDefault(m => m.Id == id));
            context.SaveChanges();
        }
    }
}
