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

        public Paciente DadosDoPaciente(int codigo)
        {
            var paciente = GetAll()
                .Include(x => x.Agendamentos)
                .FirstOrDefault(x => x.Codigo == codigo);

            var agendamentoRepository = new AgendamentoRepository();

            foreach (var item in paciente.Agendamentos)
            {
                item.Anaminese = agendamentoRepository
                    .GetAll()
                    .Include(x => x.Anaminese)
                    .FirstOrDefault(x => x.IdAgendamento == item.IdAgendamento).Anaminese;
            }

            return paciente;
        }
    }
}