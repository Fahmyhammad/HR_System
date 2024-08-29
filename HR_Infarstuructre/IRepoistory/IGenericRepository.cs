using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR_Infarstuructre.IRepoistory
{
    public interface IGenericRepository<T> where T : class
    {
      Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? perdicate = null, string? IncludeWord = null);
       Task<T> GetById(Expression<Func<T, bool>>? perdicate = null, string? IncludeWord = null);
        Task Add(T entity);
        Task Remove(T entity);
        Task RemoveRange(IEnumerable<T> entities);
    }
}
