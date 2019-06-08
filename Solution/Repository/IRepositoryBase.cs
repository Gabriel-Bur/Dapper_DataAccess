using Domain.Entities;
using System;
using System.Collections.Generic;


namespace Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(long id);
        long Insert(TEntity entity);
        bool Delete(long id);

    }
}
