using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TY.LinkConverter.Data.Migration
{
    public partial class Initial : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDeeplinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Pattern = table.Column<string>(maxLength: 1024, nullable: true),
                    ParameterizedLink = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDeeplinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToWebUrls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Pattern = table.Column<string>(maxLength: 1024, nullable: true),
                    ParameterizedLink = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToWebUrls", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ToDeeplinks",
                columns: new[] { "Id", "Active", "CreateDate", "Deleted", "ParameterizedLink", "Pattern", "UpdateDate" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 5, 25, 20, 39, 42, 892, DateTimeKind.Utc).AddTicks(7132), false, "ty://?Page=Home", null, new DateTime(2021, 5, 25, 20, 39, 42, 892, DateTimeKind.Utc).AddTicks(7663) },
                    { 2, true, new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(2672), false, "ty://?Page=Product&ContentId=[content]&CampaignId=[boutique]&MerchantId=[merchant]", "^(\\w+)+?:\\/\\/(.*)\\/(.*)\\/(.*)-p-(?<content>\\d+)\\?boutiqueId=(?<boutique>\\d+)&merchantId=(?<merchant>\\d+$)", new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(2693) },
                    { 3, true, new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(2762), false, "ty://?Page=Product&ContentId=[content]", "^(\\w+)+?:\\/\\/(.*)\\/(.*)\\/(.*)-p-(?<content>\\d+$)", new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(2763) },
                    { 4, true, new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(2782), false, "ty://?Page=Product&ContentId=[content]&CampaignId=[boutique]", "^(\\w+)+?:\\/\\/(.*)\\/(.*)\\/(.*)-p-(?<content>\\d+)\\?boutiqueId=(?<boutique>\\d+$)", new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(2783) },
                    { 5, true, new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(2801), false, "ty://?Page=Product&ContentId=[content]&MerchantId=[merchant]", "^(\\w+)+?:\\/\\/(.*)\\/(.*)/(.*)-p-(?<content>\\d+)\\?merchantId=(?<merchant>\\d+$)", new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(2802) },
                    { 6, true, new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(2829), false, "ty://?Page=Search&Query=[query]", "^(\\w+)+?:\\/\\/(.*)\\/sr\\?q=(?<query>.*$)", new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(2830) }
                });

            migrationBuilder.InsertData(
                table: "ToWebUrls",
                columns: new[] { "Id", "Active", "CreateDate", "Deleted", "ParameterizedLink", "Pattern", "UpdateDate" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(3367), false, "https://www.trendyol.com", null, new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(3370) },
                    { 2, true, new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(3527), false, "https://www.trendyol.com/brand/name-p-[content]?boutiqueId=[campaign]&merchantId=[merchant]", "^(\\w+)+?:\\/\\/(.*)\\?Page=Product&ContentId=(?<content>\\d+)&CampaignId=(?<campaign>\\d+)&MerchantId=(?<merchant>\\d+$)", new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(3528) },
                    { 3, true, new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(3549), false, "https://www.trendyol.com/brand/name-p-[content]", "^(\\w+)+?:\\/\\/(.*)\\?Page=Product&ContentId=(?<content>\\d+$)", new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(3550) },
                    { 4, true, new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(3568), false, "https://www.trendyol.com/brand/name-p-[content]?boutiqueId=[campaign]", "^(\\w+)+?:\\/\\/(.*)\\?Page=Product&ContentId=(?<content>\\d+)&CampaignId=(?<campaign>\\d+$)", new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(3569) },
                    { 5, true, new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(3588), false, "https://www.trendyol.com/brand/name-p-[content]?merchantId=[merchant]", "^(\\w+)+?:\\/\\/(.*)\\?Page=Product&ContentId=(?<content>\\d+)&MerchantId=(?<merchant>\\d+$)", new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(3589) },
                    { 6, true, new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(3609), false, "https://www.trendyol.com/sr?q=[query]", "^(\\w+)+?:\\/\\/(.*)\\?Page=Search&Query=(?<query>.*$)", new DateTime(2021, 5, 25, 20, 39, 42, 894, DateTimeKind.Utc).AddTicks(3610) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDeeplinks");

            migrationBuilder.DropTable(
                name: "ToWebUrls");
        }
    }
}
