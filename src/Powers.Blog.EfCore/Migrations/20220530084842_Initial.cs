using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Powers.Blog.EfCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    WeblogId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    ParentId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ParentUserName = table.Column<string>(type: "TEXT", nullable: true),
                    EnableMark = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeleteMark = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreateUserName = table.Column<string>(type: "TEXT", nullable: true),
                    ModifyUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifyUserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StarRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    WeblogId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StarType = table.Column<int>(type: "INTEGER", nullable: false),
                    EnableMark = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeleteMark = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreateUserName = table.Column<string>(type: "TEXT", nullable: true),
                    ModifyUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifyUserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Account = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    IsSuper = table.Column<bool>(type: "INTEGER", nullable: false),
                    EnableMark = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeleteMark = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreateUserName = table.Column<string>(type: "TEXT", nullable: true),
                    ModifyUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifyUserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weblog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    EnableMark = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeleteMark = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreateUserName = table.Column<string>(type: "TEXT", nullable: true),
                    ModifyUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifyUserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weblog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false),
                    EnableMark = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeleteMark = table.Column<bool>(type: "INTEGER", nullable: false),
                    WeblogId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreateUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreateUserName = table.Column<string>(type: "TEXT", nullable: true),
                    ModifyUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifyUserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Weblog_WeblogId",
                        column: x => x.WeblogId,
                        principalTable: "Weblog",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TagName = table.Column<string>(type: "TEXT", nullable: false),
                    EnableMark = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeleteMark = table.Column<bool>(type: "INTEGER", nullable: false),
                    WeblogId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreateUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreateUserName = table.Column<string>(type: "TEXT", nullable: true),
                    ModifyUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifyUserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_Weblog_WeblogId",
                        column: x => x.WeblogId,
                        principalTable: "Weblog",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_WeblogId",
                table: "Category",
                column: "WeblogId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_WeblogId",
                table: "Tag",
                column: "WeblogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Commit");

            migrationBuilder.DropTable(
                name: "StarRecord");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Weblog");
        }
    }
}
