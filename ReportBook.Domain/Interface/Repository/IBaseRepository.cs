using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportBook.Domain.Interface.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> GetAll();

        public Task<TEntity> CreateAsync(TEntity entity);

        public Task<TEntity> UpdateAsync(TEntity entity);

        public Task<TEntity> RemoveAsync(TEntity entity);
    }
}
