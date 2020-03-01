namespace Repository.DTO
{
    public class AgendamentoListDTO
    {
        public int IdAgendamento { get; set; }
        public string NomeProcedimento { get; set; }
        public string NomePaciente { get; set; }
        public string DataConsulta { get; set; }
        public string Horario { get; set; }
        public AnamineseListDTO Anaminese { get; set; }
    }
}
