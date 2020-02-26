using Repository.Models;
using RepositoryWebApi.Repository.EntityRepository;
using RepositoryWebApi.Repository.Models;
using System;
using System.Collections.Generic;
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
                //var todoAgendamento = repository.GetAll();
                return repository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }

           
        }

        public Agendamento SalvarAgendamento(List<Paciente> pacientes)
        {
            try
            {
                if(pacientes == null)
                {
                    throw new Exception("Não é possivel salvar um agendamento vazio!");
                }

                else if(pacientes[0].Codigo != 0)
                {
                   
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