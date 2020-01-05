namespace MultipleFileUpload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VisaApplications", "name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VisaApplications", "name");
        }
    }
}
