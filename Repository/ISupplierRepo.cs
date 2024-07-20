using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ISupplierRepo
    {
        Task<IEnumerable<SupplierCompany>> GetAllAsync();
        Task<SupplierCompany> GetByIdAsync(string id);
        Task Update(SupplierCompany supplierCompany);
        Task DeleteByIdAsync(string id);
        Task CreateSupplier(SupplierCompany supplierCompany);
    }
}
