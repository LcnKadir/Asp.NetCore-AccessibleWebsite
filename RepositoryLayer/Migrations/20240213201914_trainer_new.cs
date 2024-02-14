using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class trainer_new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Trainers",
                newName: "Branch");

            migrationBuilder.AddColumn<int>(
                name: "Password",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Trainers");

            migrationBuilder.RenameColumn(
                name: "Branch",
                table: "Trainers",
                newName: "Email");
        }
    }
}
