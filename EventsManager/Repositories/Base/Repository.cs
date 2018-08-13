using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsManager.Data;
using EventsManager.Models;
using EventsManager.Models.Records;
using EventsManager.Models.Records.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventsManager.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Record
    {
        protected EventsDb Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(EventsDb db, IQueryable<TEntity> dataset)
        {
            Db = db;
            Dataset = dataset;
            DbSet = db.Set<TEntity>();
        }

        public IQueryable<TEntity> Dataset { get; }

        public virtual async Task<TEntity> FindByIdAsync(Guid id)
        {
            TEntity entity = await Dataset.SingleOrDefaultAsync(e => e.Id == id);
            if (entity == null)
                throw new KeyNotFoundException();
            return entity;
        }

        public virtual TEntity Add(TEntity entity)
        {
            // Note that there is no protection to ensure that the entity falls
            // within the dataset
            DbSet.Add(entity);
            return entity;
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            TEntity entity = await FindByIdAsync(id);
            DbSet.Remove(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }


    }
}