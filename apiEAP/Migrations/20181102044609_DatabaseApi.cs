using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiEAP.Migrations
{
    public partial class DatabaseApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShCredentials",
                columns: table => new
                {
                    Token = table.Column<string>(nullable: false),
                    AccessToken = table.Column<string>(nullable: true),
                    MemberId = table.Column<long>(nullable: false),
                    RefreshToken = table.Column<string>(nullable: true),
                    CredentialScope = table.Column<int>(nullable: false),
                    CreatedAd = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    ExpriredAd = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShCredentials", x => x.Token);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShCredentials");
        }
    }
}
