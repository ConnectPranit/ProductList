namespace Crud_opreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Categories", "CategoryId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Products", "ProductId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Categories", "CategoryId");
            AddPrimaryKey("dbo.Products", "ProductId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Products", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "CategoryId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Products", "ProductId");
            AddPrimaryKey("dbo.Categories", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
