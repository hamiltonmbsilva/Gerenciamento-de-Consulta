using RepositoryWebApi.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Repository.Models
{
    [Serializable]
    [Table("pacientes")]
    public class Paciente
    {
       
        [Key]
        [Required, Column("id")]
        public int IdPaciente { get; set; }

        [Required, Column("codigo")]
        public int Codigo { get; set; }

        [Required, Column("nome"), MaxLength(50)]
        public string Nome { get; set; }

        [Required, Column("cpf")]
        public string CPF { get; set; }

        [Required, Column("senha"), MaxLength(21)]
        public string Senha { get; set; }

        [Required, Column("data_nascimento")]
        public DateTime DataDeNascimento { get; set; }

        [Required, Column("planos")]
        public EnumPlanos Planos { get; set; }

        //Relacionamento
        public virtual IList<Agendamento> Agendamentos { get; set; }

        public static void Map(DbModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Paciente>();

            map
            .Property(x => x.IdPaciente)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Relacionamento
            map.HasMany(a => a.Agendamentos)
                .WithRequired(a => a.Pacientes)
                .HasForeignKey(a => a.PacienteId)
                .WillCascadeOnDelete(true);
        }
    }
}