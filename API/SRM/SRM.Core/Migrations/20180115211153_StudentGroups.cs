using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SRM.Core.Migrations
{
    public partial class StudentGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ResetPasswordGuid",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentGroupId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudentGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudentGroupId",
                table: "Users",
                column: "StudentGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_StudentGroups_StudentGroupId",
                table: "Users",
                column: "StudentGroupId",
                principalTable: "StudentGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_StudentGroups_StudentGroupId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "StudentGroups");

            migrationBuilder.DropIndex(
                name: "IX_Users_StudentGroupId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ResetPasswordGuid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StudentGroupId",
                table: "Users");
        }
    }
}
