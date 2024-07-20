using DataAccessObject;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.iml
{
    public class SupplierRepo : ISupplierRepo
    {
        private readonly IDAO<SupplierCompany> _dao;
        public SupplierRepo(IDAO<SupplierCompany> dao)
        {
            _dao = dao;
        }
        public async Task CreateSupplier(SupplierCompany supplierCompany)
        {
            await _dao.Add(supplierCompany);
        }

        public async Task DeleteByIdAsync(string id)
        {
            var tmp = (await _dao.GetAll()).FirstOrDefault(p=>p.SupplierId.Equals( id));
            await _dao.Remove(tmp);
        }

        public async Task<IEnumerable<SupplierCompany>> GetAllAsync()
        {
            return await _dao.GetAll();
        }

        public async Task<SupplierCompany?> GetByIdAsync(string id)
        {
            return (await _dao.GetAll()).FirstOrDefault(p => p.SupplierId.Equals(id));
        }

        public async Task Update(SupplierCompany supplierCompany)
        {
            await _dao.Update(supplierCompany);
        }
    }
}
