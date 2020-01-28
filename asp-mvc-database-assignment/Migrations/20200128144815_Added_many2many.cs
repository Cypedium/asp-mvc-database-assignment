using Microsoft.EntityFrameworkCore.Migrations;

namespace asp_mvc_database_assignment.Migrations
{
    public partial class Added_many2many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student_Course_Map",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Course_Map", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_Student_Course_Map_Courses_Id",
                        column: x => x.Id,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Course_Map_Students_Id",
                        column: x => x.Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_Course_Map_Id",
                table: "Student_Course_Map",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student_Course_Map");
        }
    }
}
