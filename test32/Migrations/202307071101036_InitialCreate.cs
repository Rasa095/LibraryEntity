namespace test32.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UsersId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsersId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
