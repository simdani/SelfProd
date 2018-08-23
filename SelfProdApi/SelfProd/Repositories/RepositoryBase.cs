using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SelfProd.Entities;
using SelfProd.Entities.Models;
using SelfProd.Repositories.Interfaces;

namespace SelfProd.Repositories
{
    public abstract class RepositoryBase<TEntity>: IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DataContext Context;
        protected abstract DbSet<TEntity> ItemSet { get; }

        protected RepositoryBase(DataContext context)
        {
            Context = context;
        }

        protected virtual IQueryable<TEntity> IncludeDependencies(IQueryable<TEntity> queryable)
        {
            return queryable;
        }

        public virtual async Task<ICollection<TEntity>> GetAll()
        {
            var items = await IncludeDependencies(ItemSet).ToListAsync();
            return items;
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            var item = await IncludeDependencies(ItemSet).FirstOrDefaultAsync(x => x.Id == id);
            return item;
        }

        public virtual async Task<int> Create(TEntity enitity)
        {
            ItemSet.Add(enitity);
            await Context.SaveChangesAsync();
            return enitity.Id;
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            ItemSet.Attach(entity);
            var changes = await Context.SaveChangesAsync();
            return changes > 0;
        }

        public virtual async Task<bool> Delete(TEntity entity)
        {
            ItemSet.Remove(entity);
            var changes = await Context.SaveChangesAsync();
            return changes > 0;
        }
    }
}
