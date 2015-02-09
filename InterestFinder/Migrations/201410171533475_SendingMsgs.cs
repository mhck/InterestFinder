namespace InterestFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SendingMsgs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Receiver_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Messages", "Receiver_Id");
            AddForeignKey("dbo.Messages", "Receiver_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Messages", "Receiver");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Receiver", c => c.String());
            DropForeignKey("dbo.Messages", "Receiver_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "Receiver_Id" });
            DropColumn("dbo.Messages", "Receiver_Id");
        }
    }
}
