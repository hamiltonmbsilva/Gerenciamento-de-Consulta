using Gerenciamento_de_Consulta.Models;
using Gerenciamento_de_Consulta.Repository.Context;
using System.Data.Entity;

namespace Gerenciamento_de_Consulta.Repository.EntityRepository
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