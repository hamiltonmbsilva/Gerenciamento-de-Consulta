﻿using Repository.Context;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace RepositoryWebApi.Repository
{
    public abstract class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        public void Dispose()
        {
            ctx.Dispose();
        }

        BaseContext ctx = new BaseContext();

        public void Add(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            ctx.Set<TEntity>()
               .Where(predicate).ToList()
               .ForEach(del => ctx.Set<TEntity>().Remove(del));

            ctx.SaveChanges();
        }
        

        public TEntity Find(params object[] key)
        {
            return ctx.Set<TEntity>().Find(key);
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public IQueryable<TEntity> GetAll()
        {
            return ctx.Set<TEntity>();
        }

        public void SaveAll()
        {
            ctx.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            ctx.Set<TEntity>().AddOrUpdate(obj);

            //ctx.Entry(obj).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public virtual void Save(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
            ctx.SaveChanges();
        }

        public IQueryable<TEntity> GetAllByDay(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public IQueryable<TEntity> GetAllByPeriod(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }
    }
}