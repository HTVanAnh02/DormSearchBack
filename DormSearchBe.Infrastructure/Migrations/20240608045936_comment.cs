using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DormSearchBe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HousesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createdBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    deletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Houses_HousesId",
                        column: x => x.HousesId,
                        principalTable: "Houses",
                        principalColumn: "HousesId");
                    table.ForeignKey(
                        name: "FK_Comments_Users_accountId",
                        column: x => x.accountId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "CommentDescription",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id_Commnet = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RepComment3_N = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RepComment2 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    commentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createdBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    deletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentDescription_CommentDescription_RepComment2",
                        column: x => x.RepComment2,
                        principalTable: "CommentDescription",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentDescription_Comments_commentsId",
                        column: x => x.commentsId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentDescription_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentDescription_commentsId",
                table: "CommentDescription",
                column: "commentsId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentDescription_RepComment2",
                table: "CommentDescription",
                column: "RepComment2");

            migrationBuilder.CreateIndex(
                name: "IX_CommentDescription_UserId",
                table: "CommentDescription",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_accountId",
                table: "Comments",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_HousesId",
                table: "Comments",
                column: "HousesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentDescription");

            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
