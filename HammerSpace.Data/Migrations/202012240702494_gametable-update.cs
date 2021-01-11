namespace HammerSpace.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gametableupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "GameType", c => c.Int(nullable: false));
            AddColumn("dbo.Game", "IsDiceGame", c => c.Boolean());
            AddColumn("dbo.Game", "IsCardGame", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Game", "IsCardGame");
            DropColumn("dbo.Game", "IsDiceGame");
            DropColumn("dbo.Game", "GameType");
        }
    }
}
