namespace Churras.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateChurrascoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Churrascos",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Descricao = c.String(),
                    Obs = c.String(),
                    OrganizadorId = c.Int(nullable: false),
                    DateTime = c.DateTime(nullable: false),
                    Organizador_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Organizador_Id)
                .Index(t => t.Organizador_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Churrascoes", "Organizador_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Churrascoes", new[] { "Organizador_Id" });
            DropTable("dbo.Churrascoes");
        }
    }
}
