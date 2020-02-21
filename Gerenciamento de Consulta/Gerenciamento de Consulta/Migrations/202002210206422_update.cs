namespace Gerenciamento_de_Consulta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
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
                        Anaminese_id = c.Int(nullable: false),
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
                        IdAgendamento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.agendamentos", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.pacientes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.Int(nullable: false),
                        nome = c.String(nullable: false, maxLength: 50),
                        cpf = c.Int(nullable: false),
                        senha = c.String(nullable: false, maxLength: 21),
                        data_nascimento = c.DateTime(nullable: false),
                        planos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.agendamentos", "paciente_id", "dbo.pacientes");
            DropForeignKey("dbo.anamineses", "id", "dbo.agendamentos");
            DropIndex("dbo.anamineses", new[] { "id" });
            DropIndex("dbo.agendamentos", new[] { "paciente_id" });
            DropTable("dbo.pacientes");
            DropTable("dbo.anamineses");
            DropTable("dbo.agendamentos");
        }
    }
}
