namespace ToyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgeOfChildrens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Age = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Toys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Weight = c.Double(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateRelease = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                        Age_Id = c.Int(),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgeOfChildrens", t => t.Age_Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Age_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalesJournals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Toy_Fk = c.Int(nullable: false),
                        DateSale = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalesJournalToys",
                c => new
                    {
                        SalesJournal_Id = c.Int(nullable: false),
                        Toy_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SalesJournal_Id, t.Toy_Id })
                .ForeignKey("dbo.SalesJournals", t => t.SalesJournal_Id, cascadeDelete: true)
                .ForeignKey("dbo.Toys", t => t.Toy_Id, cascadeDelete: true)
                .Index(t => t.SalesJournal_Id)
                .Index(t => t.Toy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesJournalToys", "Toy_Id", "dbo.Toys");
            DropForeignKey("dbo.SalesJournalToys", "SalesJournal_Id", "dbo.SalesJournals");
            DropForeignKey("dbo.Toys", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Toys", "Age_Id", "dbo.AgeOfChildrens");
            DropIndex("dbo.SalesJournalToys", new[] { "Toy_Id" });
            DropIndex("dbo.SalesJournalToys", new[] { "SalesJournal_Id" });
            DropIndex("dbo.Toys", new[] { "Company_Id" });
            DropIndex("dbo.Toys", new[] { "Age_Id" });
            DropTable("dbo.SalesJournalToys");
            DropTable("dbo.Users");
            DropTable("dbo.Clients");
            DropTable("dbo.SalesJournals");
            DropTable("dbo.Companies");
            DropTable("dbo.Toys");
            DropTable("dbo.AgeOfChildrens");
        }
    }
}
