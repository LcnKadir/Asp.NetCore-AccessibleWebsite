using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class new_teir_for_class : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AspNetUsers_TrainerId",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "Classes",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_TrainerId",
                table: "Classes",
                newName: "IX_Classes_AppUserId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishClass",
                table: "Classes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartClass",
                table: "Classes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AspNetUsers_AppUserId",
                table: "Classes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AspNetUsers_AppUserId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "FinishClass",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "StartClass",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Classes",
                newName: "TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_AppUserId",
                table: "Classes",
                newName: "IX_Classes_TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AspNetUsers_TrainerId",
                table: "Classes",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
