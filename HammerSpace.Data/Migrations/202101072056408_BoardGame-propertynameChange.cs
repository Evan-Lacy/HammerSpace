namespace HammerSpace.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoardGamepropertynameChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "BoardGameGenre", c => c.Int());
            AddColumn("dbo.Game", "BGPublisher", c => c.String());
            AddColumn("dbo.Game", "VGPublisher", c => c.String());
            DropColumn("dbo.Game", "BoardGameaGenre");
            DropColumn("dbo.Game", "Publisher");
            DropColumn("dbo.Game", "Publisher1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "Publisher1", c => c.String());
            AddColumn("dbo.Game", "Publisher", c => c.String());
            AddColumn("dbo.Game", "BoardGameaGenre", c => c.Int());
            DropColumn("dbo.Game", "VGPublisher");
            DropColumn("dbo.Game", "BGPublisher");
            DropColumn("dbo.Game", "BoardGameGenre");
        }
    }
}
