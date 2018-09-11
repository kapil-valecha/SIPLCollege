namespace SIPLCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ManageSubjects", "ManageCourses_CourseId", "dbo.ManageCourses");
            DropIndex("dbo.ManageSubjects", new[] { "ManageCourses_CourseId" });
            RenameColumn(table: "dbo.ManageSubjects", name: "ManageCourses_CourseId", newName: "CourseId");
            AlterColumn("dbo.ManageSubjects", "CourseId", c => c.Int(nullable: true));
            CreateIndex("dbo.ManageSubjects", "CourseId");
            AddForeignKey("dbo.ManageSubjects", "CourseId", "dbo.ManageCourses", "CourseId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ManageSubjects", "CourseId", "dbo.ManageCourses");
            DropIndex("dbo.ManageSubjects", new[] { "CourseId" });
            AlterColumn("dbo.ManageSubjects", "CourseId", c => c.Int());
            RenameColumn(table: "dbo.ManageSubjects", name: "CourseId", newName: "ManageCourses_CourseId");
            CreateIndex("dbo.ManageSubjects", "ManageCourses_CourseId");
            AddForeignKey("dbo.ManageSubjects", "ManageCourses_CourseId", "dbo.ManageCourses", "CourseId");
        }
    }
}
