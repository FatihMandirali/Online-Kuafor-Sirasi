using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace BeefKuaforSiram.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //TEntity Get(int id);
        //IEnumerable<TEntity> GetAll();
        //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        //void Add(TEntity entity);
        //void AddRange(IEnumerable<TEntity> entities);

        //void Remove(TEntity entity);
        //void RemoveRange(IEnumerable<TEntity> entities);

        List<TEntity> List();
        List<TEntity> List(Expression<Func<TEntity, bool>> where);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        IQueryable<TEntity> ListQueryable();
        void Delete(TEntity obj);
        //int Save();
        TEntity Find(Expression<Func<TEntity, bool>> where);
    }
}