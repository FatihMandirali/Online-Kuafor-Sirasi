using BeefKuaforSiram.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BeefKuaforSiram.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        public Repository(DbContext context)
        {
            // context = RepositoryBase.CreateContext();//böylece tek databasecontext kullanıyoruz her defasında farklılarını kullanmıyoz...
            Context = context;
        }
        public List<TEntity> List()
        {

            return Context.Set<TEntity>().ToList();
        }
        public IQueryable<TEntity> ListQueryable()
        {
            return Context.Set<TEntity>().AsQueryable<TEntity>();
        }

        public List<TEntity> List(Expression<Func<TEntity, bool>> where)
        {
            return Context.Set<TEntity>().Where(where).ToList();

        }
        public void Insert(TEntity obj)
        {

            Context.Set<TEntity>().Add(obj);
        }
        public void Update(TEntity obj)
        {

            
        }

        public void Delete(TEntity obj)
        {
            Context.Set<TEntity>().Remove(obj);

            
        }
        //public int Save()
        //{

        //    return context.SaveChanges();
        //}
        public TEntity Find(Expression<Func<TEntity, bool>> where)
        {
            return Context.Set<TEntity>().SingleOrDefault(where);//signalordefault
        }



    }
}