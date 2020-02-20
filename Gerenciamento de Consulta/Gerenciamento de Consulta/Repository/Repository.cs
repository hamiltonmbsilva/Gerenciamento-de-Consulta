using Gerenciamento_de_Consulta.Repository.Context;
using System;
using System.Linq;

namespace Gerenciamento_de_Consulta.Repository
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
            throw new NotImplementedException();
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }
        

        public TEntity Find(params object[] key)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}