using Gerenciamento_de_Consulta.Models;
using System.Data.Entity;

namespace Gerenciamento_de_Consulta.Repository.Context
{
    public sealed class BaseContext : DbContext
    {
        public BaseContext()
            : base("name=connectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<BaseContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Paciente.Map(modelBuilder);
            Agendamento.Map(modelBuilder);
            Anaminese.Map(modelBuilder);
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Anaminese> Anamineses { get; set; }
    }
}