using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAccountRepo
    {
        Task<IEnumerable<SystemAccount>> GetAllAsync();
        Task<SystemAccount> GetByIdAsync(int id);
        Task Update(SystemAccount account);
        Task DeleteByIdAsync(int id);
        Task CreateAccount(SystemAccount account);
    }
}
