using Gerenciamento_de_Consulta.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

public sealed class PacienteMap : EntityTypeConfiguration<Pacientes>
{
    public PacienteMap()
    {
        ToTable("paciente");

        HasKey(x => x.IdPaciente)
            .Property(x => x.IdPaciente)
            .HasColumnName("id")
            .IsRequired()
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        Property(x => x.Codigo)
            .HasColumnName("codigo")
            .IsRequired();           
            
       Property(x => x.Nome)
            .HasColumnName("nome")
            .IsRequired()
            .HasMaxLength(50);

        Property(x => x.CPF)
            .HasColumnName("cpf")
            .IsRequired();

        Property(x => x.Senha)
            .HasColumnName("senha")
            .IsRequired()
            .HasMaxLength(32);

        Property(x => x.DataDeNascimento)
            .HasColumnName("data_nascimento")
            .IsRequired();
            
        Property(x => x.Planos)
            .HasColumnName("planos")
            .IsRequired();

        HasMany(a => a.Agendamentos)
            .WithRequired(a => a.Pacientes)
            .HasForeignKey(a => a.PacienteId);

    }
}