using LockerHubCore.Context;
using LockerHubCore.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LockerHubCore.Repository
{
    public class GenericRepository<T> : IGeneric<T> where T : class
    {
        protected readonly HubContext _hubContext;

        public GenericRepository(HubContext hubContext)
        {
            _hubContext = hubContext;
        }

        public void Add(T entity)
        {
            _hubContext.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _hubContext.Set<T>().AddRange(entities);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await _hubContext.Set<T>().Where(expression).ToListAsync();

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _hubContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _hubContext.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _hubContext.Set<T>().Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _hubContext.Set<T>().UpdateRange(entities);
        }

        public void Remove(T entity)
        {
            _hubContext.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _hubContext.Set<T>().RemoveRange(entities);
        }
    }
}
