namespace MultipleFileUpload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VisaApplications", "Nationality2", c => c.String());
            AddColumn("dbo.VisaApplications", "Occupation2", c => c.String());
            AddColumn("dbo.VisaApplications", "DOB", c => c.String());
            AddColumn("dbo.VisaApplications", "SpouseName", c => c.String());
            AddColumn("dbo.VisaApplications", "PhoneNo", c => c.String());
            AddColumn("dbo.VisaApplications", "Sate", c => c.String());
            AddColumn("dbo.VisaApplications", "City", c => c.String());
            AddColumn("dbo.VisaApplications", "NeighbourHood", c => c.String());
            AddColumn("dbo.VisaApplications", "Street", c => c.String());
            AddColumn("dbo.VisaApplications", "Expirydate", c => c.String());
            AddColumn("dbo.VisaApplications", "IssueDate", c => c.String());
            AddColumn("dbo.VisaApplications", "issueAtcity", c => c.String());
            AddColumn("dbo.VisaApplications", "typeOfNo", c => c.String());
            AddColumn("dbo.VisaApplications", "Durationv", c => c.String());
            AddColumn("dbo.VisaApplications", "Exarrivale", c => c.String());
            AddColumn("dbo.VisaApplications", "PurposeVisit", c => c.String());
            AddColumn("dbo.VisaApplications", "KnownAs", c => c.String());
            AddColumn("dbo.VisaApplications", "JordanNo", c => c.String());
            AddColumn("dbo.VisaApplications", "AddressInJordan", c => c.String());
            AddColumn("dbo.VisaApplications", "Durationv1", c => c.String());
            AddColumn("dbo.VisaApplications", "Exarrivale2", c => c.String());
            AddColumn("dbo.VisaApplications", "PurposeVisit3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VisaApplications", "PurposeVisit3");
            DropColumn("dbo.VisaApplications", "Exarrivale2");
            DropColumn("dbo.VisaApplications", "Durationv1");
            DropColumn("dbo.VisaApplications", "AddressInJordan");
            DropColumn("dbo.VisaApplications", "JordanNo");
            DropColumn("dbo.VisaApplications", "KnownAs");
            DropColumn("dbo.VisaApplications", "PurposeVisit");
            DropColumn("dbo.VisaApplications", "Exarrivale");
            DropColumn("dbo.VisaApplications", "Durationv");
            DropColumn("dbo.VisaApplications", "typeOfNo");
            DropColumn("dbo.VisaApplications", "issueAtcity");
            DropColumn("dbo.VisaApplications", "IssueDate");
            DropColumn("dbo.VisaApplications", "Expirydate");
            DropColumn("dbo.VisaApplications", "Street");
            DropColumn("dbo.VisaApplications", "NeighbourHood");
            DropColumn("dbo.VisaApplications", "City");
            DropColumn("dbo.VisaApplications", "Sate");
            DropColumn("dbo.VisaApplications", "PhoneNo");
            DropColumn("dbo.VisaApplications", "SpouseName");
            DropColumn("dbo.VisaApplications", "DOB");
            DropColumn("dbo.VisaApplications", "Occupation2");
            DropColumn("dbo.VisaApplications", "Nationality2");
        }
    }
}
