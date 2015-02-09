namespace InterestFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "IsPublic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "IsPublic", c => c.Boolean(nullable: false));
        }
    }
}
