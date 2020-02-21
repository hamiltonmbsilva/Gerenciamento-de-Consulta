using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Gerenciamento_de_Consulta.Models
{
    [Table("agendamentos")]
    public class Agendamento
    {
        [Key]
        [Required, Column("id")]
        public int IdAgendamento { get; set; }

        [Required, Column("data_consulta")]
        public DateTime Data_Consulta { get; set; }

        [Required, Column("nome_procedimento"), MaxLength(100)]
        public string Nome_Procedimento { get; set; }

        [Required, Column("horario")]
        public DateTime Horario { get; set; }

        //Relacionamento
        [Required, Column("paciente_id")]
        public int PacienteId { get; set; }
        public virtual Paciente Pacientes { get; set; }

        //Relacionamento
        public int Anaminese_id { get; set; }
        public virtual Anaminese Anaminese { get; set; }

        public static void Map(DbModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Agendamento>();

            map.Property(x => x.IdAgendamento)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //map.HasOptional(x => x.Anaminese).WithRequired(p => p.Agendamento);

            //Relacionamento
            map.HasRequired(x => x.Pacientes)
                .WithMany(x => x.Agendamentos)
                .HasForeignKey(c => c.PacienteId);
        }
    }
}