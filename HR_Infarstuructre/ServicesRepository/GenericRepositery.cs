using HR_Infarstuructre.Data;
using HR_Infarstuructre.IRepoistory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR_Infarstuructre.ServicesRepository
{
    public class GenericRepositery<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        private DbSet<T> _dbSet;

        public GenericRepositery(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();

        }

        public async Task Add(T entity)
        {
          await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? perdicate = null, string? IncludeWord = null)
        {
            IQueryable<T> query = _dbSet;
            if (perdicate != null)
            {
                query = query.Where(perdicate);
            }
            if (IncludeWord != null)
            {
                foreach (var item in IncludeWord.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetById(Expression<Func<T, bool>>? perdicate = null, string? IncludeWord = null)
        {
            IQueryable<T> query = _dbSet;

            if (perdicate != null)
            {
                query = query.Where(perdicate);
            }

            if (!string.IsNullOrEmpty(IncludeWord))
            {
                foreach (var includeProperty in IncludeWord.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task Remove(T entity)
        {
           _dbSet.Remove(entity);
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
