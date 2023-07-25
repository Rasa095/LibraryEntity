namespace test32.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrantt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        BookAuthor = c.String(),
                        BookPurchase = c.DateTime(nullable: false),
                        BookPrice = c.Int(nullable: false),
                        BookQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}
