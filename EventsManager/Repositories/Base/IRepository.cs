using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsManager.Models;
using EventsManager.Models.Records;
using EventsManager.Models.Records.Base;

namespace EventsManager.Repositories.Base
{
    public interface IRepository<TEntity> 
        where TEntity : Record
    {
        IQueryable<TEntity> Dataset { get; }

        Task<TEntity> FindByIdAsync(Guid id);

        TEntity Add(TEntity entity);

        Task RemoveAsync(Guid id);

        void Remove(TEntity entity);
    }
}