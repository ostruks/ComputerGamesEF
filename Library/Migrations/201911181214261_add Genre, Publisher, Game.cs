namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGenrePublisherGame : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 60),
                        YearOfIssue = c.Int(nullable: false),
                        Genre_Id = c.Int(nullable: false),
                        Publisher_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.Publisher_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Publisher_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(maxLength: 600),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        License = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Publisher_Id", "dbo.Publishers");
            DropForeignKey("dbo.Games", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Games", new[] { "Publisher_Id" });
            DropIndex("dbo.Games", new[] { "Genre_Id" });
            DropTable("dbo.Publishers");
            DropTable("dbo.Genres");
            DropTable("dbo.Games");
        }
    }
}
