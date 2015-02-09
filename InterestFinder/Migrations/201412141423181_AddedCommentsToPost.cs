namespace InterestFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCommentsToPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Post_PostID", c => c.Int());
            AlterColumn("dbo.Posts", "HeaderText", c => c.String());
            CreateIndex("dbo.Posts", "Post_PostID");
            AddForeignKey("dbo.Posts", "Post_PostID", "dbo.Posts", "PostID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Post_PostID", "dbo.Posts");
            DropIndex("dbo.Posts", new[] { "Post_PostID" });
            AlterColumn("dbo.Posts", "HeaderText", c => c.String(nullable: false));
            DropColumn("dbo.Posts", "Post_PostID");
        }
    }
}
