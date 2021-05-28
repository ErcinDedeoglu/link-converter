using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TY.LinkConverter.Context;
using TY.LinkConverter.Data.Interface;

namespace TY.LinkConverter.Data.Service
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _entities;

        public Repository(DataContext dataContext)
        {
            _entities = dataContext.Set<T>();
        }

        public T Insert(T entity)
        {
            _entities.Add(entity);

            return entity;
        }

        public T InsertAsync(T entity)
        {
            _entities.AddAsync(entity);

            return entity;
        }

        public void PurgeAll()
        {
            _entities.RemoveRange(_entities);
        }

        public T Update(T entity)
        {
            _entities.Update(entity);

            return entity;
        }

        public void Purge(T entity)
        {
            _entities.Remove(entity);
        }

        public T Get(int id)
        {
            return _entities.Find(id);
        }

        public ValueTask<T> GetAsync(int id)
        {
            return _entities.FindAsync(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _entities.ToListAsync();
        }


        public IQueryable<T> Query()
        {
            return _entities;
        }

        public T Random()
        {
            return _entities.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        }

        public Task<T> RandomAsync()
        {
            return _entities.OrderBy(x => Guid.NewGuid()).FirstOrDefaultAsync();
        }
    }
}