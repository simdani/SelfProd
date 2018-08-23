using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SelfProd.Entities.Models;

namespace SelfProd.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<ICollection<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<int> Create(TEntity enitity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
    }
}
