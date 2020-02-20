using Gerenciamento_de_Consulta.Models;
using System.Data.Entity;

namespace Gerenciamento_de_Consulta.Repository.Context
{
    public sealed class BaseContext : DbContext
    {
        public BaseContext()
            :base("name=MysqlConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<BaseContext>(null);
        }

        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Anaminese> Anaminese { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PacienteMap());
            modelBuilder.Configurations.Add(new AgendamentoMap());
            modelBuilder.Configurations.Add(new AnamineseMap());           
        }


    }
}