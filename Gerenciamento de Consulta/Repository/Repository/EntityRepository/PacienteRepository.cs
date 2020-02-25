
using Repository.Models;
using Repository.Context;
using System.Data.Entity;


namespace RepositoryWebApi.Repository.EntityRepository
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