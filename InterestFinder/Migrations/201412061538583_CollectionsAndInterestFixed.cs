namespace InterestFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollectionsAndInterestFixed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Interest_InterestId", "dbo.Interests");
            DropIndex("dbo.Posts", new[] { "Interest_InterestId" });
            RenameColumn(table: "dbo.Posts", name: "Interest_InterestId", newName: "InterestID");
            AlterColumn("dbo.Posts", "InterestID", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "InterestID");
            AddForeignKey("dbo.Posts", "InterestID", "dbo.Interests", "InterestID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "InterestID", "dbo.Interests");
            DropIndex("dbo.Posts", new[] { "InterestID" });
            AlterColumn("dbo.Posts", "InterestID", c => c.Int());
            RenameColumn(table: "dbo.Posts", name: "InterestID", newName: "Interest_InterestId");
            CreateIndex("dbo.Posts", "Interest_InterestId");
            AddForeignKey("dbo.Posts", "Interest_InterestId", "dbo.Interests", "InterestId");
        }
    }
}
