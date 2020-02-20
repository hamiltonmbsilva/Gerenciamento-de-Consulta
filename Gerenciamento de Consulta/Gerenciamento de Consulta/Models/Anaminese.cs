using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gerenciamento_de_Consulta.Models
{
    public class Anaminese
    {
        [Key]
        public int IdAnaminese { get; set; }

        public string Sintoma { get; set; }
        public string Doenca_Existente { get; set; }

        public Partes_Corpos Partes_Corpo { get; set; }

        public virtual Agendamento Agendamento { get; set; }
    }
}