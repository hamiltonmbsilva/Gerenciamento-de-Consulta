using Repository.Models;
using RepositoryWebApi.Repository.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace RepositoryWebApi.Repository.EntityRepository
{
    public class AgendamentoRepository : Repository<Agendamento>
    {
        public IQueryable<Agendamento> AgendamentosDoDia(DateTime dia)
        {
            var diaAnterio = dia.AddDays(-1);
            var diasPosterior = dia.AddDays(1);

            return GetAll()
                .Include(x => x.Pacientes)// adiciona os dados dos pacientes
                .Include(x => x.Anaminese)// adiciona os dados da anaminese
                .Where(x => x.DataConsulta > diaAnterio && x.DataConsulta < diasPosterior);
        }

        public IQueryable<Agendamento> AgendamentosPeriodoPlano(DateTime diaInicial, DateTime diaFinal, EnumPlanos plano)
        {
            return GetAll()
                .Include(x => x.Pacientes)// adiciona os dados dos pacientes
                .Include(x => x.Anaminese)// adiciona os dados da anaminese
                .Where(x => x.DataConsulta >= diaInicial && x.DataConsulta <= diaFinal)// busca pelo periodo
                .Where(x => x.Pacientes.Planos == plano);
        }
    }
}