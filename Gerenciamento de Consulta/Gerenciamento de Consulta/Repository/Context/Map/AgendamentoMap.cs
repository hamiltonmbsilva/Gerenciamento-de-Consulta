using Gerenciamento_de_Consulta.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

public sealed class AgendamentoMap: EntityTypeConfiguration<Agendamento>
{
    public AgendamentoMap()
    {
        ToTable("agendamento");


        HasKey(x => x.IdAgendamento)
            .Property(x => x.IdAgendamento)
            .HasColumnName("id")
            .IsRequired()
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
       
        Property(x => x.Data_Consulta)
          .HasColumnName("data_consulta")
          .IsRequired();

        Property(x => x.Nome_Procedimento)
           .HasColumnName("nome_procedimento")
           .IsRequired()
           .HasMaxLength(100);

        Property(x => x.Horario)
           .HasColumnName("horario")
           .IsRequired();

        Property(x => x.PacienteId)
           .HasColumnName("paciente_id")
           .IsRequired();

        HasRequired(x => x.Pacientes)
            .WithMany(x => x.Agendamentos)
            .HasForeignKey(c => c.PacienteId);


        HasOptional(x => x.Anaminese)
            .WithRequired(x => x.Agendamento);

    }
}