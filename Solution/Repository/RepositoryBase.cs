using Domain.Entities;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace Repository
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        protected readonly string _ConnectionString;

        protected RepositoryBase()
        {
            _ConnectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
           using(var db = new SqlConnection(_ConnectionString))
           {
                return db.GetAll<TEntity>();
           }
        }

        public virtual TEntity GetById(long id)
        {
            using(var db = new SqlConnection(_ConnectionString))
            {
                return db.Get<TEntity>(id);
            }
        }

        public virtual long Insert(TEntity entity)
        {
            using(var db = new SqlConnection(_ConnectionString))
            {
                return db.Insert<TEntity>(entity);
            }
        }

        public virtual bool Delete(long id)
        {
            using (var db = new SqlConnection(_ConnectionString))
            {
                var entity = GetById(id);

                if (entity == null) return false;

                return db.Delete(entity);
            }
        }

    }
}
