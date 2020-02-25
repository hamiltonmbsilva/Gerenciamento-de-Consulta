using Repository.Models;
using Repository.Context;
using System.Data.Entity;


namespace RepositoryWebApi.Repository.EntityRepository
{
    public class AnamineseRepository : Repository<Anaminese>
    {
        BaseContext ctx = new BaseContext();

        public void UpdateAnaminese(Anaminese obj)
        {
            ctx.Entry(obj).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}