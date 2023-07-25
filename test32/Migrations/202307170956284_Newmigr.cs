namespace test32.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newmigr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IssueBooks", "ReturnDateIssueBook", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IssueBooks", "ReturnDateIssueBook", c => c.DateTime(nullable: false));
        }
    }
}
