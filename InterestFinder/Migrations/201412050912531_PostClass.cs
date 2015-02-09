namespace InterestFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        HeaderText = c.String(),
                        ContentText = c.String(),
                        TimePosted = c.DateTime(nullable: false),
                        Sender_Id = c.String(maxLength: 128),
                        Interest_InterestID = c.Int(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.AspNetUsers", t => t.Sender_Id)
                .ForeignKey("dbo.Interests", t => t.Interest_InterestID)
                .Index(t => t.Sender_Id)
                .Index(t => t.Interest_InterestID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Interest_InterestID", "dbo.Interests");
            DropForeignKey("dbo.Posts", "Sender_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "Interest_InterestID" });
            DropIndex("dbo.Posts", new[] { "Sender_Id" });
            DropTable("dbo.Posts");
        }
    }
}
