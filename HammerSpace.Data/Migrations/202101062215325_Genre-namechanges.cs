namespace HammerSpace.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genrenamechanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "BoardGameaGenre", c => c.Int());
            AddColumn("dbo.Game", "VideoGameGenre", c => c.Int());
            DropColumn("dbo.Game", "Genre");
            DropColumn("dbo.Game", "Genre1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "Genre1", c => c.Int());
            AddColumn("dbo.Game", "Genre", c => c.Int());
            DropColumn("dbo.Game", "VideoGameGenre");
            DropColumn("dbo.Game", "BoardGameaGenre");
        }
    }
}
