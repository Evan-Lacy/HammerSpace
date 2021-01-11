namespace HammerSpace.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Testing : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Game");
            AddColumn("dbo.Game", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Game", "GameId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Game", "UserId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Game");
            AlterColumn("dbo.Game", "GameId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Game", "UserId");
            AddPrimaryKey("dbo.Game", "GameId");
        }
    }
}
