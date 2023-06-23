using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MercedesURLShortener.Repository.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Url",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CurrentUrl = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ShortUrl = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    VisitorCount = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Url", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Url",
                columns: new[] { "Id", "CreatedDate", "CurrentUrl", "DeletedDate", "Description", "ShortUrl", "UpdatedDate", "VisitorCount" },
                values: new object[] { 1, new DateTime(2023, 6, 23, 0, 45, 43, 485, DateTimeKind.Utc).AddTicks(4613), "https://www.mercedes-benz.com.tr/passengercars/mercedes-benz-cars/car-configurator.html/motorization/CCci/TR/tr/GT-KLASSE/4-TUERER%20COUPE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hayalinde ki Mercedes'i kendi zevkine göre tasarla", "https://mb.com/3Dbenz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Url");
        }
    }
}
