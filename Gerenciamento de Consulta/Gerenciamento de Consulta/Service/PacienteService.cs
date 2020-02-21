using Gerenciamento_de_Consulta.Models;
using Gerenciamento_de_Consulta.Repository.EntityRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gerenciamento_de_Consulta.Service
{
    public class PacienteService
    {
        private PacienteRepository repository = new PacienteRepository();


        public IEnumerable<Paciente> BuscarTodosOsPacinetes()
        {
            return repository.GetAll();
        }

        public Paciente SalvarPaciente(Paciente paciente)
        {
            try
            {
                if (paciente == null)
                    throw new Exception("Não é possivel salvar um Paciente vazio");

                int idade = DateTime.Now.Year - paciente.DataDeNascimento.Year;
                if (DateTime.Now.DayOfWeek < paciente.DataDeNascimento.DayOfWeek)
                {
                    idade = idade - 1;
                }

                if (idade > 18 && paciente.Codigo != 0 && paciente.CPF != 0)
                {
                    var codigo = repository.Get(x => x.Codigo == paciente.Codigo).FirstOrDefault();

                    var cpf = repository.Get(x => x.CPF == paciente.CPF).FirstOrDefault();

                    if (codigo != null)
                    {
                        throw new Exception("Não é possivel salvar o Paciente com um código duplicado!");
                    }
                    else if (cpf != null)
                    {
                        throw new Exception("Não é possivel salvar o Paciente com um CPF duplicado!");
                    }
                    else
                    {
                        paciente.DataDeNascimento = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                        repository.Save(paciente);
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