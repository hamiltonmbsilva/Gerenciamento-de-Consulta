using Gerenciamento_de_Consulta.Models;
using Gerenciamento_de_Consulta.Repository.EntityRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gerenciamento_de_Consulta.Service
{
    public class PacienteService
    {
        private PacienteRepository paciente = new PacienteRepository();
        

        public IEnumerable<Pacientes> BuscarTodosOsPacinetes()
        {
            return paciente.GetAll();
        }

        public Pacientes SalvarPaciente(Pacientes p)
        {
            if (p == null)
                throw new Exception("Não é possivel salvar um Paciente vazio");

            int idade = DateTime.Now.Year - p.DataDeNascimento.Year;
            if(DateTime.Now.DayOfWeek < p.DataDeNascimento.DayOfWeek)
            {
                idade = idade - 1;
            }

            if (idade > 18 && p.Codigo != 0 && p.CPF != 0)
            {
                var codigo = paciente.Get(x => x.Codigo == p.Codigo).FirstOrDefault();

                var cpf = paciente.Get(x => x.CPF == p.CPF).FirstOrDefault();

                if(codigo != null)
                {
                    throw new Exception("Não é possivel salvar o Paciente com um código duplicado!");
                }
                else if(cpf != null)
                {
                    throw new Exception("Não é possivel salvar o Paciente com um CPF duplicado!");
                }
                else
                {
                    p.DataDeNascimento = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                    paciente.Save(p);
                }

            }
            return null;
        }
    }
}