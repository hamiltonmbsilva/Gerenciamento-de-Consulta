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
        public int PacienteId { get; set; }
        public virtual Pacientes Pacientes { get; set; } 

        public virtual Anaminese Anaminese { get; set; } 

        
    }
}