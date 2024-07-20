using DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.iml
{
    public class DAO<T> : IDAO<T> where T : class
    {
        private readonly OilPaintingArt2024DbContext _context;
        private readonly DbSet<T> _dbSet;

        public DAO(OilPaintingArt2024DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task Add(T t)
        {
            await _dbSet.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }

        public async Task Remove(T t)
        {
            _dbSet.Remove(t);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T t)
        {
            _dbSet.Update(t);
            await _context.SaveChangesAsync();
        }
    }
}
