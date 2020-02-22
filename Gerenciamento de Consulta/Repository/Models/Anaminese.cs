using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Repository.Models
{
    [Table("anamineses")]
    public class Anaminese
    {
        [Key]
        [Required, Column("id")]
        public int IdAnaminese { get; set; }

        [Required, Column("sintoma"), MaxLength(150)]
        public string Sintoma { get; set; }

        [Required, Column("doenca_existente"), MaxLength(150)]
        public string DoencaExistente { get; set; }

        [Required, Column("parte_corpo")]
        public EnumPartesCorpos PartesCorpo { get; set; }

        [Required]
        public virtual Agendamento Agendamento { get; set; }

        public static void Map(DbModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Anaminese>();

            map.Property(x => x.IdAnaminese)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}