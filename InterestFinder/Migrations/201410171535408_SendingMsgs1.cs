namespace InterestFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SendingMsgs1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "ReceiverName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "ReceiverName", c => c.String(nullable: false));
        }
    }
}
