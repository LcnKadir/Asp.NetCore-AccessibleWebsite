using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class blogs_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Trainers_TrainerId1",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_TrainerId1",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "TrainerId1",
                table: "Blogs");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Trainers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TrainerId",
                table: "Blogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionThree",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionTwo",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LoginDescription",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LoginDescriptionTwo",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LoginTitle",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_TrainerId",
                table: "Blogs",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Trainers_TrainerId",
                table: "Blogs",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Trainers_TrainerId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_TrainerId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "DescriptionThree",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "DescriptionTwo",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "LoginDescription",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "LoginDescriptionTwo",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "LoginTitle",
                table: "Blogs");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "TrainerId",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TrainerId1",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_TrainerId1",
                table: "Blogs",
                column: "TrainerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Trainers_TrainerId1",
                table: "Blogs",
                column: "TrainerId1",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
