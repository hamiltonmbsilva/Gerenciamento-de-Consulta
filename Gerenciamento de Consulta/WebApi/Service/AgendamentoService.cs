using Repository.DTO;
using Repository.Map;
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

        public IEnumerable<Agendamento> BuscarTodosOsAgendamento()
        {
            try
            {
                var todoAgendamento = repository.GetAll();
                todoAgendamento = todoAgendamento.Include(x => x.Pacientes);
                return todoAgendamento;
            }
            catch(Exception ex)
            {
                throw ex;
            }

           
        }

        public Agendamento BuscarAgendamentoPeloId(int id)
        {

            try
            {
                if(id != 0)
                {
                    var agendamento = repository.GetAll().Include(x => x.Pacientes).Include(x => x.Anaminese);
                    return agendamento.FirstOrDefault(x => x.IdAgendamento == id);
                    
                }

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            
        }

        public Agendamento SalvarAgendamento(Agendamento agendamento)
        {
            try
            {
                if(agendamento == null )
                {
                    throw new Exception("Não é possivel salvar um agendamento vazio!");
                }

                if(agendamento.PacienteId == 0)
                {
                    throw new Exception("Não é possivel salvar um agendamento sem paciente!");
                }

                repository.Save(agendamento);

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

        public List<AgendamentoListDTO> AgendamentosDoDia(DateTime dia)
        {
            var agendamentos = repository.AgendamentosDoDia(dia).ToList();

            var map = MapConfig.GetMap();// pega a configuração do automapper

            var listDto = new List<AgendamentoListDTO>();

            foreach (var agendamento in agendamentos)
            {
                var mapeado = map.Map<Agendamento, AgendamentoListDTO>(agendamento);// realiza o mapeamento

                listDto.Add(mapeado);
            }

            return listDto;
        }

        public List<AgendamentoListDTO> AgendamentosPeriodoPlano(DateTime diaInicial, DateTime diaFinal, EnumPlanos plano)
        {
            var agendamentos = repository.AgendamentosPeriodoPlano(diaInicial, diaFinal, plano).ToList();

            var map = MapConfig.GetMap();// pega a configuração do automapper

            var listDto = new List<AgendamentoListDTO>();

            foreach (var agendamento in agendamentos)
            {
                var mapeado = map.Map<Agendamento, AgendamentoListDTO>(agendamento);// realiza o mapeamento

                listDto.Add(mapeado);
            }

            return listDto;
        }

        public bool ExcluirAgendamento(int? id)
        {
            try
            {
                if (id != null)
                {
                    var agRepository = new AgendamentoRepository();

                    var agendamento = repository.Find(id);

                    if (agendamento != null)
                    {
                        repository.Delete(x => x.IdAgendamento == id);
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}