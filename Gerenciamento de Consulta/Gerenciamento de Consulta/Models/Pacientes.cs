using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gerenciamento_de_Consulta.Models
{
    public class Pacientes
    {
        [Key]
        public int IdPaciente { get; set; }
        [Required]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        [Required]
        public int CPF { get; set; }
        public string Senha { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
        [Required]
        public Planos Planos { get; set; } 

        public Pacientes()
        {
            Agendamentos = new HashSet<Agendamento>();
        }

    }
}