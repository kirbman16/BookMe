namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Details = c.String(),
                        Fee = c.Double(nullable: false),
                        Period = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        PerfomerId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Performer", t => t.PerfomerId, cascadeDelete: true)
                .Index(t => t.PerfomerId);
            
            CreateTable(
                "dbo.Performer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        StageName = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        HidePhoneNumber = c.Boolean(nullable: false),
                        HideEmail = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Account", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 100),
                        PasswordHash = c.String(nullable: false),
                        PasswordSalt = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Details = c.String(),
                        ContactName = c.String(nullable: false),
                        ContactNumber = c.String(),
                        ContactEmail = c.String(),
                        HideContactInfo = c.Boolean(nullable: false),
                        City = c.String(),
                        State = c.Int(),
                        ZipCode = c.String(),
                        AccountId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.Int(),
                        Zip = c.String(),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        EndDate = c.DateTime(nullable: false, storeType: "date"),
                        Budget = c.Double(),
                        Status = c.Int(nullable: false),
                        CancellationDate = c.DateTime(storeType: "date"),
                        OrganizationId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organization", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.EventNeed",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Event", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        PerformerId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Details = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Event", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Performer", t => t.PerformerId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.PerformerId);
            
            CreateTable(
                "dbo.EventRequestNegotiation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fee = c.Double(nullable: false),
                        Period = c.Int(nullable: false),
                        PerformerAgrees = c.Boolean(nullable: false),
                        OrganizationAgrees = c.Boolean(nullable: false),
                        DateSent = c.DateTime(storeType: "date"),
                        DateAgreed = c.DateTime(storeType: "date"),
                        CancellationDate = c.DateTime(storeType: "date"),
                        EventRequestId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventRequest", t => t.EventRequestId, cascadeDelete: true)
                .Index(t => t.EventRequestId);
            
            CreateTable(
                "dbo.ErrorLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppName = c.String(nullable: false),
                        Thread = c.String(nullable: false),
                        Level = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Message = c.String(nullable: false),
                        Exception = c.String(nullable: false),
                        LogDate = c.DateTime(nullable: false, storeType: "date"),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rate", "PerfomerId", "dbo.Performer");
            DropForeignKey("dbo.EventRequest", "PerformerId", "dbo.Performer");
            DropForeignKey("dbo.Performer", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Event", "OrganizationId", "dbo.Organization");
            DropForeignKey("dbo.EventRequestNegotiation", "EventRequestId", "dbo.EventRequest");
            DropForeignKey("dbo.EventRequest", "EventId", "dbo.Event");
            DropForeignKey("dbo.EventNeed", "EventId", "dbo.Event");
            DropForeignKey("dbo.EventNeed", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Performer", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Organization", "AccountId", "dbo.Account");
            DropIndex("dbo.EventRequestNegotiation", new[] { "EventRequestId" });
            DropIndex("dbo.EventRequest", new[] { "PerformerId" });
            DropIndex("dbo.EventRequest", new[] { "EventId" });
            DropIndex("dbo.EventNeed", new[] { "CategoryId" });
            DropIndex("dbo.EventNeed", new[] { "EventId" });
            DropIndex("dbo.Event", new[] { "OrganizationId" });
            DropIndex("dbo.Organization", new[] { "AccountId" });
            DropIndex("dbo.Performer", new[] { "AccountId" });
            DropIndex("dbo.Performer", new[] { "CategoryId" });
            DropIndex("dbo.Rate", new[] { "PerfomerId" });
            DropTable("dbo.ErrorLog");
            DropTable("dbo.EventRequestNegotiation");
            DropTable("dbo.EventRequest");
            DropTable("dbo.Category");
            DropTable("dbo.EventNeed");
            DropTable("dbo.Event");
            DropTable("dbo.Organization");
            DropTable("dbo.Account");
            DropTable("dbo.Performer");
            DropTable("dbo.Rate");
        }
    }
}
