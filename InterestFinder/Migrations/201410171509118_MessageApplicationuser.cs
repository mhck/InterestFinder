namespace InterestFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageApplicationuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Receiver_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Messages", "Sender_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Messages", "Receiver_Id");
            CreateIndex("dbo.Messages", "Sender_Id");
            AddForeignKey("dbo.Messages", "Receiver_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Messages", "Sender_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Messages", "Sender");
            DropColumn("dbo.Messages", "Receiver");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Receiver", c => c.String());
            AddColumn("dbo.Messages", "Sender", c => c.String());
            DropForeignKey("dbo.Messages", "Sender_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "Receiver_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            DropIndex("dbo.Messages", new[] { "Receiver_Id" });
            DropColumn("dbo.Messages", "Sender_Id");
            DropColumn("dbo.Messages", "Receiver_Id");
        }
    }
}
