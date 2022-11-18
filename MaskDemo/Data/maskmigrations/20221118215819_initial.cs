using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaskDemo.data.maskmigrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaskType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaskType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Masks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    MaskTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Masks_MaskType_MaskTypeId",
                        column: x => x.MaskTypeId,
                        principalTable: "MaskType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Masks_MaskTypeId",
                table: "Masks",
                column: "MaskTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Masks");

            migrationBuilder.DropTable(
                name: "MaskType");
        }
    }
}
