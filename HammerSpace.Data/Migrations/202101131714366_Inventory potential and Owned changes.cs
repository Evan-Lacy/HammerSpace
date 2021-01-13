namespace HammerSpace.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventorypotentialandOwnedchanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryId);
            
            CreateTable(
                "dbo.OwnedGames",
                c => new
                    {
                        OwnedGameId = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        InventoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OwnedGameId)
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Inventory", t => t.InventoryId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.InventoryId);
            
            CreateTable(
                "dbo.OwnedMovies",
                c => new
                    {
                        OwnedMovieId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        InventoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OwnedMovieId)
                .ForeignKey("dbo.Inventory", t => t.InventoryId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.InventoryId);
            
            AddColumn("dbo.ApplicationUser", "Inventory_InventoryId", c => c.Int());
            CreateIndex("dbo.ApplicationUser", "Inventory_InventoryId");
            AddForeignKey("dbo.ApplicationUser", "Inventory_InventoryId", "dbo.Inventory", "InventoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUser", "Inventory_InventoryId", "dbo.Inventory");
            DropForeignKey("dbo.OwnedMovies", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.OwnedMovies", "InventoryId", "dbo.Inventory");
            DropForeignKey("dbo.OwnedGames", "InventoryId", "dbo.Inventory");
            DropForeignKey("dbo.OwnedGames", "GameId", "dbo.Game");
            DropIndex("dbo.ApplicationUser", new[] { "Inventory_InventoryId" });
            DropIndex("dbo.OwnedMovies", new[] { "InventoryId" });
            DropIndex("dbo.OwnedMovies", new[] { "MovieId" });
            DropIndex("dbo.OwnedGames", new[] { "InventoryId" });
            DropIndex("dbo.OwnedGames", new[] { "GameId" });
            DropColumn("dbo.ApplicationUser", "Inventory_InventoryId");
            DropTable("dbo.OwnedMovies");
            DropTable("dbo.OwnedGames");
            DropTable("dbo.Inventory");
        }
    }
}
