using AutoMapper;

using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Linq;

namespace web_basics.business.Domains
{
    public class Account
    {
        IMapper mapper;
        data.Repositories.Account repository;

        public Account(IConfiguration configuration)
        {
            this.repository = new data.Repositories.Account(configuration);
            this.mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<data.Entities.Account, ViewModels.Account>();
                cfg.CreateMap<ViewModels.Account, data.Entities.Account>();
            }).CreateMapper();
        }

        public IEnumerable<ViewModels.Account> Get()
        {
            var accounts = repository.Get();
            return accounts.Select(account => mapper.Map<data.Entities.Account, ViewModels.Account>(account));
        }
        public void Create(ViewModels.Account acc)
        {
            this.repository.Create(mapper.Map<ViewModels.Account, data.Entities.Account>(acc));
        }
        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
        public void Edit(ViewModels.Account account)
        {
            this.repository.Edit(mapper.Map<ViewModels.Account, data.Entities.Account>(account));
        }
    }
}
