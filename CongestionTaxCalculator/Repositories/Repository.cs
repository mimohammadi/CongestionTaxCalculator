using CongestionTaxCalculator.DbContext;
using CongestionTaxCalculator.Interface;
using CongestionTaxCalculator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Repositories
{
    /// <summary>
    /// read /write repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract class Repository<TEntity, TKey> :
          IWriteRepository<TEntity, TKey>
        , IReadRepository<TEntity, TKey>
        , IDeleteRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>, IAggregateRoot
        where TKey : struct
    {
        public DataBaseContext _dbContext { protected get; set; }

        protected Repository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }



        public async Task Update(TKey key, TEntity entity)
        {
            var find = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(t => t.Id.Equals(key));
            if (find != null)
            {
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetList(int skip = 0, int take = 10)
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().OrderByDescending(t => t.Id).Skip(skip * take).Take(take).ToListAsync();

        }

        public IQueryable<TEntity> GetQuerable()
        {
            var result = _dbContext.Set<TEntity>().AsNoTracking().OrderByDescending(x => x.Id).AsQueryable();
            return result;
        }

        public async Task Delete(TEntity entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task Delete(TKey key)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }


    }
}
