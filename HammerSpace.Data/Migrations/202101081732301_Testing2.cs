namespace HammerSpace.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Testing2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Game");
            AlterColumn("dbo.Game", "GameId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Game", "GameId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Game");
            AlterColumn("dbo.Game", "GameId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Game", "UserId");
        }
    }
}
