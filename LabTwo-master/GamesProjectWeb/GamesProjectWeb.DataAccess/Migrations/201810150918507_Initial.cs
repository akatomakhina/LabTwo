namespace GamesProjectWeb.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Link = c.String(nullable: false),
                        LinkRSS = c.String(nullable: false),
                        LastModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        PubDate = c.DateTime(),
                        Link = c.String(nullable: false),
                        Enclosure = c.String(),
                        Guid = c.String(),
                        ChannelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Channels", t => t.ChannelId, cascadeDelete: true)
                .Index(t => t.ChannelId);
            
            CreateTable(
                "dbo.FavoriteGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastModified = c.DateTime(),
                        UserId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FavoriteGames", "UserId", "dbo.Users");
            DropForeignKey("dbo.FavoriteGames", "GameId", "dbo.Games");
            DropForeignKey("dbo.Games", "ChannelId", "dbo.Channels");
            DropIndex("dbo.FavoriteGames", new[] { "GameId" });
            DropIndex("dbo.FavoriteGames", new[] { "UserId" });
            DropIndex("dbo.Games", new[] { "ChannelId" });
            DropTable("dbo.Users");
            DropTable("dbo.FavoriteGames");
            DropTable("dbo.Games");
            DropTable("dbo.Channels");
        }
    }
}
