namespace InterestFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Messages1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ReceiverName", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "Receiver", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "Receiver", c => c.String(nullable: false));
            DropColumn("dbo.Messages", "ReceiverName");
        }
    }
}
