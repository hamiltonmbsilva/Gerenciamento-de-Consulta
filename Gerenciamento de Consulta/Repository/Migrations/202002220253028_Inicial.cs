namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.agendamentos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        data_consulta = c.DateTime(nullable: false),
                        nome_procedimento = c.String(nullable: false, maxLength: 100),
                        horario = c.DateTime(nullable: false),
                        paciente_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.pacientes", t => t.paciente_id, cascadeDelete: true)
                .Index(t => t.paciente_id);
            
            CreateTable(
                "dbo.anamineses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        sintoma = c.String(nullable: false, maxLength: 150),
                        doenca_existente = c.String(nullable: false, maxLength: 150),
                        parte_corpo = c.Int(nullable: false),
                        Agendamento_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.agendamentos", t => t.Agendamento_Id)
                .Index(t => t.Agendamento_Id);
            
            CreateTable(
                "dbo.pacientes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.Int(nullable: false),
                        nome = c.String(nullable: false, maxLength: 50),
                        cpf = c.String(nullable: false),
                        senha = c.String(nullable: false, maxLength: 21),
                        data_nascimento = c.DateTime(nullable: false),
                        planos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.agendamentos", "paciente_id", "dbo.pacientes");
            DropForeignKey("dbo.anamineses", "Agendamento_Id", "dbo.agendamentos");
            DropIndex("dbo.anamineses", new[] { "Agendamento_Id" });
            DropIndex("dbo.agendamentos", new[] { "paciente_id" });
            DropTable("dbo.pacientes");
            DropTable("dbo.anamineses");
            DropTable("dbo.agendamentos");
        }
    }
}
