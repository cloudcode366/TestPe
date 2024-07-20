using DataAccessObject;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.iml
{
    public class AccountRepo : IAccountRepo
    {
        private readonly IDAO<SystemAccount> _dao;
        public AccountRepo(IDAO<SystemAccount> dao)
        {
            _dao = dao;
        }

        public async Task CreateAccount(SystemAccount account)
        {
            await _dao.Add(account);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var acc = (await _dao.GetAll()).FirstOrDefault(u => u.AccountId == id);
            await _dao.Remove(acc);
        }

        public async Task<IEnumerable<SystemAccount>> GetAllAsync()
        {
            return await _dao.GetAll();
        }

        public async Task<SystemAccount?> GetByIdAsync(int id)
        {
            return (await _dao.GetAll()).FirstOrDefault(p => p.AccountId == id);
        }

        public async Task Update(SystemAccount account)
        {
            await _dao.Update(account);
        }
    }
}
