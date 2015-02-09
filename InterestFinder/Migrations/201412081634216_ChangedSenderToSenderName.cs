namespace InterestFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedSenderToSenderName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "SenderName", c => c.String());
            DropColumn("dbo.Messages", "Sender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Sender", c => c.String());
            DropColumn("dbo.Messages", "SenderName");
        }
    }
}
