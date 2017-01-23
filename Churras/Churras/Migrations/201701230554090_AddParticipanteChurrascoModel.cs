namespace Churras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParticipanteChurrascoModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParticipanteChurrascoes",
                c => new
                    {
                        ChurrascoId = c.Int(nullable: false),
                        ParticipanteId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ChurrascoId, t.ParticipanteId })
                .ForeignKey("dbo.Churrascos", t => t.ChurrascoId)
                .ForeignKey("dbo.AspNetUsers", t => t.ParticipanteId, cascadeDelete: true)
                .Index(t => t.ChurrascoId)
                .Index(t => t.ParticipanteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParticipanteChurrascoes", "ParticipanteId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ParticipanteChurrascoes", "ChurrascoId", "dbo.Churrascos");
            DropIndex("dbo.ParticipanteChurrascoes", new[] { "ParticipanteId" });
            DropIndex("dbo.ParticipanteChurrascoes", new[] { "ChurrascoId" });
            DropTable("dbo.ParticipanteChurrascoes");
        }
    }
}
