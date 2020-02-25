using Repository.Models;
using RepositoryWebApi.Repository.EntityRepository;
using RepositoryWebApi.Repository.Models;
using System;

namespace Repository
{
    public class Program
    {
        private static PacienteRepository pacienteRepository = new PacienteRepository();
        private static AgendamentoRepository agendamentoRepository = new AgendamentoRepository();

        static void Main(string[] args)
        {
            Console.WriteLine("Criando Passiente: ");

            Paciente paciente = new Paciente();

            paciente.Codigo = 985;
            paciente.Nome = "Pedrin";
            paciente.CPF = "000.000.000-00";
            paciente.Senha = "698";
            paciente.DataDeNascimento = DateTime.Now;

            pacienteRepository.Save(paciente);

            Console.WriteLine("Criando Agendamento: ");

            Agendamento agendamento = new Agendamento();
            agendamento.PacienteId = paciente.IdPaciente;

            agendamento.DataConsulta = DateTime.Now;
            agendamento.NomeProcedimento = "Consulta";

            var horario = "22:48";
            var horarios = horario.Split(':');
            agendamento.Horario = new DateTime(
                agendamento.DataConsulta.Year,// Ano
                agendamento.DataConsulta.Month,// Mes
                agendamento.DataConsulta.Day,// dia
                Convert.ToInt32(horarios[0]),// horas
                Convert.ToInt32(horarios[1]),// minutos
                0// segundos
            );

            Console.WriteLine("Criando Anaminese: ");

            Anaminese anaminese = new Anaminese();

            anaminese.Sintoma = "dor de cabeça";
            anaminese.DoencaExistente = "nenhuma";
            anaminese.PartesCorpo = EnumPartesCorpos.Cabeça;

            agendamento.Anaminese = anaminese;

            agendamentoRepository.Save(agendamento);

            Console.ReadKey();
        }
    }
}