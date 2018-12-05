namespace OnlineBillPay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAccountState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AccountState", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AccountState");
        }
    }
}
