namespace InterestFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Messages : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "Receiver_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "Sender_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "Receiver_Id" });
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            AddColumn("dbo.Messages", "Sender", c => c.String());
            AddColumn("dbo.Messages", "Receiver", c => c.String());
            DropColumn("dbo.Messages", "Receiver_Id");
            DropColumn("dbo.Messages", "Sender_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Sender_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Messages", "Receiver_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Messages", "Receiver");
            DropColumn("dbo.Messages", "Sender");
            CreateIndex("dbo.Messages", "Sender_Id");
            CreateIndex("dbo.Messages", "Receiver_Id");
            AddForeignKey("dbo.Messages", "Sender_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Messages", "Receiver_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
