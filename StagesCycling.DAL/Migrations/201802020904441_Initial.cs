namespace StagesCycling.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aerobars",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Sourcing = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDefinedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SKU = c.String(),
                        DefaultSC2 = c.Boolean(nullable: false),
                        DefaultSC3 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArtworkBeltGuards",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Color = c.String(),
                        ImageUrl = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDefinedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cycles",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ModelId = c.Long(nullable: false),
                        HandlebarTypeId = c.Long(nullable: false),
                        PlasticsColorTypeId = c.Long(nullable: false),
                        SprintShiftTypeId = c.Long(nullable: false),
                        PowerMeterTypeId = c.Long(nullable: false),
                        PedalTypeId = c.Long(),
                        ConsoleTypeId = c.Long(),
                        SeatTypeId = c.Long(),
                        ArtworkBeltGuardId = c.Long(nullable: false),
                        ArtworkFlywheelId = c.Long(nullable: false),
                        ArtworkFrameForkId = c.Long(nullable: false),
                        PaintColorId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArtworkBeltGuards", t => t.ArtworkBeltGuardId, cascadeDelete: true)
                .ForeignKey("dbo.ArtworkFlywheels", t => t.ArtworkFlywheelId, cascadeDelete: true)
                .ForeignKey("dbo.ArtworkFrameForks", t => t.ArtworkFrameForkId, cascadeDelete: true)
                .ForeignKey("dbo.PowerMeterTypes", t => t.PowerMeterTypeId, cascadeDelete: true)
                .ForeignKey("dbo.HandlebarTypes", t => t.HandlebarTypeId)
                .ForeignKey("dbo.Models", t => t.ModelId)
                .ForeignKey("dbo.Orders", t => t.Id)
                .ForeignKey("dbo.PaintColors", t => t.PaintColorId)
                .ForeignKey("dbo.PlasticsColorTypes", t => t.PlasticsColorTypeId)
                .ForeignKey("dbo.SprintShiftTypes", t => t.SprintShiftTypeId)
                .Index(t => t.Id)
                .Index(t => t.ModelId)
                .Index(t => t.HandlebarTypeId)
                .Index(t => t.PlasticsColorTypeId)
                .Index(t => t.SprintShiftTypeId)
                .Index(t => t.PowerMeterTypeId)
                .Index(t => t.ArtworkBeltGuardId)
                .Index(t => t.ArtworkFlywheelId)
                .Index(t => t.ArtworkFrameForkId)
                .Index(t => t.PaintColorId);
            
            CreateTable(
                "dbo.ArtworkFlywheels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Color = c.String(),
                        ImageUrl = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDefinedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArtworkFrameForks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Color = c.String(),
                        ImageUrl = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDefinedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PowerMeterTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Sourcing = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDefinedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SKU = c.String(),
                        DefaultSC2 = c.Boolean(nullable: false),
                        DefaultSC3 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HandlebarTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Sourcing = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDefinedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SKU = c.String(),
                        DefaultSC2 = c.Boolean(nullable: false),
                        DefaultSC3 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Sourcing = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDefinedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SKU = c.String(),
                        DefaultSC2 = c.Boolean(nullable: false),
                        DefaultSC3 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IsTabletHolder = c.Boolean(nullable: false),
                        TabletHolderQuantity = c.Int(nullable: false),
                        IsPhoneHolder = c.Boolean(nullable: false),
                        PhoneHolderQuantity = c.Int(nullable: false),
                        IsMediaShelf = c.Boolean(nullable: false),
                        MediaShelfQuantity = c.Int(nullable: false),
                        IsSeatPost = c.Boolean(nullable: false),
                        SeatPostQuantity = c.Int(nullable: false),
                        IsHandlebarPost = c.Boolean(nullable: false),
                        HandlebarPostQuantity = c.Int(nullable: false),
                        IsStagesDumbbellHolder = c.Boolean(nullable: false),
                        StagesDumbbellHolderQuantity = c.Int(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        AerobarQuantity = c.Int(nullable: false),
                        AerobarId = c.Long(),
                        StagesBikeNumberPlateQuantity = c.Int(nullable: false),
                        StagesBikeNumberPlateId = c.Long(),
                        CycleQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        GrossPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Int(nullable: false),
                        NetPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                        CreateSalesOrder = c.Boolean(nullable: false),
                        DateTimeAdded = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PaintColors",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RALCode = c.String(),
                        ColorImageUrl = c.String(),
                        BikeImageUrl = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlasticsColorTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Sourcing = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDefinedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SKU = c.String(),
                        DefaultSC2 = c.Boolean(nullable: false),
                        DefaultSC3 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SprintShiftTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Sourcing = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDefinedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SKU = c.String(),
                        DefaultSC2 = c.Boolean(nullable: false),
                        DefaultSC3 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConsoleTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Sourcing = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDefinedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SKU = c.String(),
                        DefaultSC2 = c.Boolean(nullable: false),
                        DefaultSC3 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PedalTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Sourcing = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDefinedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SKU = c.String(),
                        DefaultSC2 = c.Boolean(nullable: false),
                        DefaultSC3 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.SeatTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Sourcing = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDefinedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SKU = c.String(),
                        DefaultSC2 = c.Boolean(nullable: false),
                        DefaultSC3 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StagesBikeNumberPlates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Sourcing = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDefinedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SKU = c.String(),
                        DefaultSC2 = c.Boolean(nullable: false),
                        DefaultSC3 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Cycles", "SprintShiftTypeId", "dbo.SprintShiftTypes");
            DropForeignKey("dbo.Cycles", "PlasticsColorTypeId", "dbo.PlasticsColorTypes");
            DropForeignKey("dbo.Cycles", "PaintColorId", "dbo.PaintColors");
            DropForeignKey("dbo.Cycles", "Id", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "Id", "dbo.Orders");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cycles", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Cycles", "HandlebarTypeId", "dbo.HandlebarTypes");
            DropForeignKey("dbo.Cycles", "PowerMeterTypeId", "dbo.PowerMeterTypes");
            DropForeignKey("dbo.Cycles", "ArtworkFrameForkId", "dbo.ArtworkFrameForks");
            DropForeignKey("dbo.Cycles", "ArtworkFlywheelId", "dbo.ArtworkFlywheels");
            DropForeignKey("dbo.Cycles", "ArtworkBeltGuardId", "dbo.ArtworkBeltGuards");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OrderDetails", new[] { "Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Orders", new[] { "ApplicationUserId" });
            DropIndex("dbo.Cycles", new[] { "PaintColorId" });
            DropIndex("dbo.Cycles", new[] { "ArtworkFrameForkId" });
            DropIndex("dbo.Cycles", new[] { "ArtworkFlywheelId" });
            DropIndex("dbo.Cycles", new[] { "ArtworkBeltGuardId" });
            DropIndex("dbo.Cycles", new[] { "PowerMeterTypeId" });
            DropIndex("dbo.Cycles", new[] { "SprintShiftTypeId" });
            DropIndex("dbo.Cycles", new[] { "PlasticsColorTypeId" });
            DropIndex("dbo.Cycles", new[] { "HandlebarTypeId" });
            DropIndex("dbo.Cycles", new[] { "ModelId" });
            DropIndex("dbo.Cycles", new[] { "Id" });
            DropTable("dbo.StagesBikeNumberPlates");
            DropTable("dbo.SeatTypes");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PedalTypes");
            DropTable("dbo.ConsoleTypes");
            DropTable("dbo.SprintShiftTypes");
            DropTable("dbo.PlasticsColorTypes");
            DropTable("dbo.PaintColors");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Orders");
            DropTable("dbo.Models");
            DropTable("dbo.HandlebarTypes");
            DropTable("dbo.PowerMeterTypes");
            DropTable("dbo.ArtworkFrameForks");
            DropTable("dbo.ArtworkFlywheels");
            DropTable("dbo.Cycles");
            DropTable("dbo.ArtworkBeltGuards");
            DropTable("dbo.Aerobars");
        }
    }
}
