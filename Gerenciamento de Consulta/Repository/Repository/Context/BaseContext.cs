using Repository.Models;
using RepositoryWebApi.Repository.Models;
using System.Data.Entity;


namespace Repository.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext()
            : base("name=connectionString")
        {
            Configuration.LazyLoadingEnabled = false; //habilita o lazyloading
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<BaseContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // cria o banco com code frist

            Paciente.Map(modelBuilder); // chama o mapeamento da classe Paciente
            Agendamento.Map(modelBuilder); // chama o mapeamento da classe Agendamento
            Anaminese.Map(modelBuilder); // chama o mapeamento da classe Anaminese
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Anaminese> Anamineses { get; set; }
    }
}