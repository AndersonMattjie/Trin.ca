namespace Churras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewAttrParticipanteChurras : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParticipanteChurras", "ValorContribuicao", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ParticipanteChurras", "IsPago", c => c.Boolean(nullable: false));
            AddColumn("dbo.ParticipanteChurras", "ComBebida", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ParticipanteChurras", "ComBebida");
            DropColumn("dbo.ParticipanteChurras", "IsPago");
            DropColumn("dbo.ParticipanteChurras", "ValorContribuicao");
        }
    }
}
