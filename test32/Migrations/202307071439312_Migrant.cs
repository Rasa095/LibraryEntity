﻿namespace test32.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrant : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.Int(nullable: false));
        }
    }
}
