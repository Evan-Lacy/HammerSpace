namespace HammerSpace.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeeddataandfirstrunaftermergingGameandMoviebranches : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieTitle = c.String(nullable: false),
                        MovieDescription = c.String(nullable: false),
                        MovieRunTime = c.Double(nullable: false),
                        Director = c.String(),
                        MovieRating = c.Int(nullable: false),
                        MovieGenre = c.Int(nullable: false),
                        ReleaseYear = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        public override void Down()
        {
            DropTable("dbo.Movie");
        }
        
    }
}
