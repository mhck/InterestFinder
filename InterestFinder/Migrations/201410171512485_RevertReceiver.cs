namespace InterestFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertReceiver : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "Receiver_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "Receiver_Id" });
            AddColumn("dbo.Messages", "Receiver", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "Content", c => c.String(nullable: false));
            DropColumn("dbo.Messages", "Receiver_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Receiver_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Messages", "Content", c => c.String());
            DropColumn("dbo.Messages", "Receiver");
            CreateIndex("dbo.Messages", "Receiver_Id");
            AddForeignKey("dbo.Messages", "Receiver_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
