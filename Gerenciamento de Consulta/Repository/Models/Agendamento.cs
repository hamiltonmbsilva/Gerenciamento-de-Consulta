using Repository.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace RepositoryWebApi.Repository.Models
{
    [Table("agendamentos")]
    public class Agendamento
    {
        [Key]
        [Required, Column("id")]
        public int IdAgendamento { get; set; }

        [Required, Column("data_consulta")]
        public DateTime DataConsulta { get; set; }

        [Required, Column("nome_procedimento"), MaxLength(100)]
        public string NomeProcedimento { get; set; }

        [Required, Column("horario")]
        public DateTime Horario { get; set; }

        //Relacionamento
        [Required, Column("paciente_id")]
        public int PacienteId { get; set; }
        public virtual Paciente Pacientes { get; set; }

        //Relacionamento
        public virtual Anaminese Anaminese { get; set; }

        public static void Map(DbModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Agendamento>();

            map.Property(x => x.IdAgendamento)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Relacionamento
            map.HasRequired(x => x.Pacientes)
                .WithMany(x => x.Agendamentos)
                .HasForeignKey(c => c.PacienteId);

            //1:1
            modelBuilder.Entity<Anaminese>().HasRequired(fk => fk.Agendamento).WithOptional(c => c.Anaminese).Map(m => m.MapKey("Agendamento_Id"));
        }
    }
}