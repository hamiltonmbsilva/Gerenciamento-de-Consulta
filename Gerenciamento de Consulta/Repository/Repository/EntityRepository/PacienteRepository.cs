
using Repository.Models;
using Repository.Repository.Context;
using System.Data.Entity;

namespace Repository.Repository.EntityRepository
{
    public class PacienteRepository : Repository<Paciente>
    {
        BaseContext ctx = new BaseContext();

        public void UpdatePaciente(Paciente obj)
        {
            ctx.Entry(obj).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}