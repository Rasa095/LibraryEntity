namespace test32.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ccccc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IssueBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        StudentEmail = c.String(),
                        StudentDepartment = c.String(),
                        StudentContact = c.Int(nullable: false),
                        Semester = c.Int(nullable: false),
                        IssueBookName = c.String(),
                        IssuBookDate = c.DateTime(nullable: false),
                        ReturnDateIssueBook = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IssueBooks");
        }
    }
}
