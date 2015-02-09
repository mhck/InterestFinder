namespace InterestFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAnnotationsForPosts : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "HeaderText", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "ContentText", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "ContentText", c => c.String());
            AlterColumn("dbo.Posts", "HeaderText", c => c.String());
        }
    }
}
