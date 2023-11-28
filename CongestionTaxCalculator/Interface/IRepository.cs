using CongestionTaxCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Interface
{
    public interface IRepository : IDisposable, IAsyncDisposable
    {
    }
    public interface IRepository<TEntity, TKey> : IDisposable, IAsyncDisposable
       where TEntity : BaseEntity<TKey>, IAggregateRoot
       where TKey : struct
    {
    }


    public interface IReadRepository<TEntity, TKey> : IRepository<TEntity, TKey>
     where TEntity : BaseEntity<TKey>, IAggregateRoot
     where TKey : struct
    {
        IQueryable<TEntity> GetQuerable();
        Task<IEnumerable<TEntity>> GetList(int skip = 0, int take = 10);



    }

    public interface IQueryRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>, IAggregateRoot
    where TKey : struct
    {
        IQueryable<TEntity> GetQuerable();
    }

    public interface IWriteRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>, IAggregateRoot
        where TKey : struct
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
    }


    public interface IDeleteRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>, IAggregateRoot
        where TKey : struct
    {
        Task Delete(TKey key);
    }

    public interface IUsageRepository<TEntity, TKey> : IRepository<TEntity, TKey>
  where TEntity : BaseEntity<TKey>, IAggregateRoot
  where TKey : struct
    {
        Task<bool> IsUsage(TKey key);


    }

}
