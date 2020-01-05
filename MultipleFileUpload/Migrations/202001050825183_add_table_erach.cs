namespace MultipleFileUpload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table_erach : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VisaApplications", "date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.VisaApplications", "Durationv", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VisaApplications", "Durationv", c => c.String());
            DropColumn("dbo.VisaApplications", "date");
        }
    }
}
