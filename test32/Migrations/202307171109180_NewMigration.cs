namespace test32.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IssueBooks", "EnrollmentNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.IssueBooks", "EnrollmentNo");
        }
    }
}
