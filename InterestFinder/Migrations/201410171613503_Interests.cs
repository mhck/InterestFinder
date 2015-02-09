namespace InterestFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Interests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        InterestID = c.Int(nullable: false, identity: true),
                        InterestName = c.String(),
                        Category = c.String(),
                        AdultOnly = c.Boolean(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.InterestID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interests", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Interests", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Interests");
        }
    }
}
