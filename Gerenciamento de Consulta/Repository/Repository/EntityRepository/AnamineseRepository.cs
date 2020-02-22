using Repository.Models;
using Repository.Repository.Context;
using System.Data.Entity;

namespace Repository.Repository.EntityRepository
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