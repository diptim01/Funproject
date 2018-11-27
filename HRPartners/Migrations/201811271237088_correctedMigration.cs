namespace HRPartners.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctedMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Budgets",
                c => new
                    {
                        BudgetId = c.Int(nullable: false, identity: true),
                        FicsID = c.Int(nullable: false),
                        SeismicId = c.Int(nullable: false),
                        ExpenditureId = c.Int(nullable: false),
                        PartnerId = c.Int(nullable: false),
                        IsBudgetApproved = c.Boolean(nullable: false),
                        IsSentToNexs = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BudgetId)
                .ForeignKey("dbo.ExpenditueModels", t => t.ExpenditureId, cascadeDelete: true)
                .ForeignKey("dbo.FicsModels", t => t.FicsID, cascadeDelete: true)
                .ForeignKey("dbo.PartnerModels", t => t.PartnerId, cascadeDelete: true)
                .ForeignKey("dbo.SeismicModels", t => t.SeismicId, cascadeDelete: true)
                .Index(t => t.FicsID)
                .Index(t => t.SeismicId)
                .Index(t => t.ExpenditureId)
                .Index(t => t.PartnerId);
            
            CreateTable(
                "dbo.ExpenditueModels",
                c => new
                    {
                        ExpenditureId = c.Int(nullable: false, identity: true),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.ExpenditureId);
            
            CreateTable(
                "dbo.FicsModels",
                c => new
                    {
                        FicsModelID = c.Int(nullable: false, identity: true),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.FicsModelID);
            
            CreateTable(
                "dbo.PartnerModels",
                c => new
                    {
                        PartnersId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        EstimatedValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PartnersId);
            
            CreateTable(
                "dbo.SeismicModels",
                c => new
                    {
                        SeismicModelID = c.Int(nullable: false, identity: true),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.SeismicModelID);
            
            CreateTable(
                "dbo.Nexs",
                c => new
                    {
                        NexsId = c.Int(nullable: false, identity: true),
                        PartnersId = c.Int(nullable: false),
                        FicBudget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SeismicBudget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExpenditureBudget = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.NexsId)
                .ForeignKey("dbo.PartnerModels", t => t.PartnersId, cascadeDelete: true)
                .Index(t => t.PartnersId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nexs", "PartnersId", "dbo.PartnerModels");
            DropForeignKey("dbo.Budgets", "SeismicId", "dbo.SeismicModels");
            DropForeignKey("dbo.Budgets", "PartnerId", "dbo.PartnerModels");
            DropForeignKey("dbo.Budgets", "FicsID", "dbo.FicsModels");
            DropForeignKey("dbo.Budgets", "ExpenditureId", "dbo.ExpenditueModels");
            DropIndex("dbo.Nexs", new[] { "PartnersId" });
            DropIndex("dbo.Budgets", new[] { "PartnerId" });
            DropIndex("dbo.Budgets", new[] { "ExpenditureId" });
            DropIndex("dbo.Budgets", new[] { "SeismicId" });
            DropIndex("dbo.Budgets", new[] { "FicsID" });
            DropTable("dbo.Nexs");
            DropTable("dbo.SeismicModels");
            DropTable("dbo.PartnerModels");
            DropTable("dbo.FicsModels");
            DropTable("dbo.ExpenditueModels");
            DropTable("dbo.Budgets");
        }
    }
}
