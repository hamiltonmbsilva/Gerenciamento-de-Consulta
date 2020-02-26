using Repository.Models;
using RepositoryWebApi.Repository.EntityRepository;
using RepositoryWebApi.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WebApi.Service
{
    public class AgendamentoService
    {
        private AgendamentoRepository repository = new AgendamentoRepository();
        private PacienteRepository pacienteService = new PacienteRepository();
        private AnamineseRepository anamineseService = new AnamineseRepository();



        public IEnumerable<Agendamento> BuscarTodosOsAgendamento()
        {
            try
            {
                var todoAgendamento = repository.GetAll();
                todoAgendamento = todoAgendamento.Include(x => x.Pacientes).Include(x => x.Anaminese);
                return todoAgendamento;
            }
            catch(Exception ex)
            {
                throw ex;
            }

           
        }

        public Agendamento BuscarAgendamentoPeloId(int? id)
        {

            try
            {
                if(id != 0)
                {                   

                    return repository.Find(id);
                }

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            
        }

        public Agendamento SalvarAgendamento(List<Paciente> pacientes, List<Anaminese> anamineses)
        {
            try
            {
                if(pacientes == null && anamineses == null)
                {
                    throw new Exception("Não é possivel salvar um agendamento vazio!");
                }

                else if(pacientes[0].Codigo != 0)
                {
                    var paciente = new Paciente();
                    var agendamento = new Agendamento();

                    //Convertendo a data para remover informações desnecessarias - 2019/06/30T23:00:00
                    paciente.DataDeNascimento = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                    agendamento.DataConsulta = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

                    pacienteService.Save(paciente);

                    Anaminese anaminese = new Anaminese();

                    agendamento.Anaminese = anaminese;

                    repository.Save(agendamento);

                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Agendamento> BuscarAgendamentoPeloIntervalo(DateTime dataInicial, DateTime dataFinal)
        {

            try
            {
                if (dataInicial != null && dataInicial != new DateTime())
                if (dataFinal != null && dataFinal != new DateTime())
                    return (List<Agendamento>)repository.Get(x => x.DataConsulta >= dataInicial && x.DataConsulta <= dataFinal);

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public Agendamento AlterarAgendamento(Agendamento agend)
        {
            try
            {
                if(agend == null)
                {
                   throw new Exception("Não é possivel alterar um agendamento vazio!");
                }
                else if(agend.IdAgendamento != 0)
                {
                    // está mantendo o produto "p" em memória e não está buscando no banco
                    var oldAgendamento = repository.Find(agend.IdAgendamento);

                    //Busca se existe algum agendamento cadastrado com mesmo horario
                    if(agend.Horario != oldAgendamento.Horario)
                    {
                        var horario = repository.Get(x => x.Horario == agend.Horario).FirstOrDefault();
                        if(horario != null)
                        {
                            throw new Exception("Não é possivel alterar um agendamento com um horario duplicado!");
                        }
                    }
                    else
                    {
                        repository.Update(agend);
                        return agend;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}