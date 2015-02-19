namespace InterestFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUsername : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Sender_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "Sender_Id" });
            AddColumn("dbo.Posts", "Sender", c => c.String());
            DropColumn("dbo.Posts", "Sender_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Sender_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Posts", "Sender");
            CreateIndex("dbo.Posts", "Sender_Id");
            AddForeignKey("dbo.Posts", "Sender_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
