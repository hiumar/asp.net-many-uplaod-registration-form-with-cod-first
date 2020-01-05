namespace MultipleFileUpload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mfiles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        SupportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VisaApplications", t => t.SupportId, cascadeDelete: true)
                .Index(t => t.SupportId);
            
            CreateTable(
                "dbo.VisaApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SureName = c.String(),
                        LastName = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        MotherName = c.String(),
                        Nationality = c.String(),
                        DateOfbirth = c.String(),
                        PlaceOfBirth = c.String(),
                        EmployerAddress = c.String(),
                        Occupation = c.String(),
                        Employer = c.String(),
                        option1 = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mfiles", "SupportId", "dbo.VisaApplications");
            DropIndex("dbo.Mfiles", new[] { "SupportId" });
            DropTable("dbo.VisaApplications");
            DropTable("dbo.Mfiles");
        }
    }
}
