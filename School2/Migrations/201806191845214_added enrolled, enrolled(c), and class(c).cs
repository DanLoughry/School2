namespace School2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedenrolledenrolledcandclassc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        MajorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Majors", t => t.MajorId, cascadeDelete: false)
                .Index(t => t.MajorId);
            
            CreateTable(
                "dbo.Enrolleds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Grade = c.String(),
                        StudentId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.ClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrolleds", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Enrolleds", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Classes", "MajorId", "dbo.Majors");
            DropIndex("dbo.Enrolleds", new[] { "ClassId" });
            DropIndex("dbo.Enrolleds", new[] { "StudentId" });
            DropIndex("dbo.Classes", new[] { "MajorId" });
            DropTable("dbo.Enrolleds");
            DropTable("dbo.Classes");
        }
    }
}
