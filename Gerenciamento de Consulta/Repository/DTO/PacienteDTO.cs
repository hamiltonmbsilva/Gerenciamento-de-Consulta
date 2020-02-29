using System.Collections.Generic;

namespace Repository.DTO
{
    public class PacienteListDTO
    {
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public string CPF { get; set; }
        public string DataDeNascimento { get; set; }
        public string Planos { get; set; }
        public List<AgendamentoListDTO> Agendamentos { get; set; }
    }
}
