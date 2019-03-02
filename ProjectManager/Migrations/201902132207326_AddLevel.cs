namespace ProjectManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLevel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TreeConstructorModels", "Level", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TreeConstructorModels", "Level");
        }
    }
}
