using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gerenciamento_de_Consulta.Models
{
    public class Anaminese
    {
        [Key]
        public int IdAnaminese { get; set; }

        public string Sintoma { get; set; }
        public string Doenca_Exixtente { get; set; }

        public List<Partes_Corpos> Partes_Corpo { get; set; } = new List<Partes_Corpos>();
    }
}