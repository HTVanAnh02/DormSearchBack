using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DormSearchBe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class abcd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AcreagesAcreageId",
                table: "Houses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Acreage",
                columns: table => new
                {
                    AcreageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Acreages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    deletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acreage", x => x.AcreageId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Houses_AcreagesAcreageId",
                table: "Houses",
                column: "AcreagesAcreageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Acreage_AcreagesAcreageId",
                table: "Houses",
                column: "AcreagesAcreageId",
                principalTable: "Acreage",
                principalColumn: "AcreageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Acreage_AcreagesAcreageId",
                table: "Houses");

            migrationBuilder.DropTable(
                name: "Acreage");

            migrationBuilder.DropIndex(
                name: "IX_Houses_AcreagesAcreageId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "AcreagesAcreageId",
                table: "Houses");
        }
    }
}
