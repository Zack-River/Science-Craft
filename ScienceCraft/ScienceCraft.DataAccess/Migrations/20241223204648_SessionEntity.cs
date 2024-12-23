using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScienceCraft.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SessionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Sessions",
                newName: "LastModified");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Sessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "Sessions",
                newName: "Date");
        }
    }
}
