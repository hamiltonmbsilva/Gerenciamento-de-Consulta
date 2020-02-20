using Gerenciamento_de_Consulta.Models;
using System.Data.Entity.ModelConfiguration;

public sealed class AnamineseMap: EntityTypeConfiguration<Anaminese>
{
    public AnamineseMap()
    {
        ToTable("anaminese");

        HasKey(x => x.IdAnaminese)
            .Property(x => x.IdAnaminese)
            .HasColumnName("id")
            .IsRequired();

        Property(x => x.Sintoma)
            .HasColumnName("sintoma")
            .IsRequired()
            .HasMaxLength(150);

        Property(x => x.Doenca_Existente)
            .HasColumnName("doenca_existente")
            .IsRequired()
            .HasMaxLength(150);

        Property(x => x.Partes_Corpo)
            .HasColumnName("parte_corpo")
            .IsRequired();

        HasRequired(x => x.Agendamento)
            .WithOptional(x => x.Anaminese);
           
    }
}