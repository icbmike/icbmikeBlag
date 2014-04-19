namespace IcbmikeBlag.Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PosterName = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                        Content = c.String(),
                        Comment_ID = c.Int(),
                        BlogPost_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Comments", t => t.Comment_ID)
                .ForeignKey("dbo.BlogPosts", t => t.BlogPost_ID)
                .Index(t => t.Comment_ID)
                .Index(t => t.BlogPost_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "BlogPost_ID", "dbo.BlogPosts");
            DropForeignKey("dbo.Comments", "Comment_ID", "dbo.Comments");
            DropIndex("dbo.Comments", new[] { "BlogPost_ID" });
            DropIndex("dbo.Comments", new[] { "Comment_ID" });
            DropTable("dbo.Comments");
            DropTable("dbo.BlogPosts");
        }
    }
}
