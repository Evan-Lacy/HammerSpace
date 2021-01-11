namespace HammerSpace.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameShitgettingFixed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        GameTitle = c.String(nullable: false),
                        GameDescription = c.String(nullable: false),
                        AveragePlaytime = c.Double(nullable: false),
                        MinGamePlayers = c.Int(nullable: false),
                        MaxGamePlayers = c.Int(),
                        Genre = c.Int(),
                        Category = c.String(),
                        Publisher = c.String(),
                        LocalCoop = c.Boolean(),
                        Genre1 = c.Int(),
                        ESRBRating = c.Int(),
                        Publisher1 = c.String(),
                        Console = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Game");
        }
    }
}
