using Microsoft.EntityFrameworkCore.Migrations;

namespace asp_mvc_database_assignment.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Student_Course_Map",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Student_Course_Map_TeacherId",
                table: "Student_Course_Map",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Course_Map_Teachers_TeacherId",
                table: "Student_Course_Map",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Course_Map_Teachers_TeacherId",
                table: "Student_Course_Map");

            migrationBuilder.DropIndex(
                name: "IX_Student_Course_Map_TeacherId",
                table: "Student_Course_Map");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Student_Course_Map");
        }
    }
}
