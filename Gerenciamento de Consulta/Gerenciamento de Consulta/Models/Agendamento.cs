using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gerenciamento_de_Consulta.Models
{
    public class Agendamento
    {
        [Key]
        public int IdAgendamento { get; set; }
        public DateTime Data_Consulta { get; set; }
        public string Nome_Procedimento { get; set; }
        public DateTime Horario { get; set; }
        public List<Pacientes> Lista_Pacientes { get; set; } = new List<Pacientes>();

        public Anaminese Anaminese { get; set; } 
    }
}