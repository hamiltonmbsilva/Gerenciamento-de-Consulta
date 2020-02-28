using Repository.Models;
using Repository.Context;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<object> GetPacientesSelect()
        {
            var selects = GetAll().Select(x => new { Id = x.IdPaciente, Nome = x.Nome });

            return selects;
        }
    }
}