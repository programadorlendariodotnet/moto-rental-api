using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CnhTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "varchar", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CnhTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Cnpj = table.Column<string>(type: "varchar", maxLength: 14, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    CnhNumber = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    CnhType = table.Column<short>(type: "smallint", nullable: false),
                    CnhImageUrl = table.Column<string>(type: "varchar", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPersons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motorcycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    Model = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Plate = table.Column<string>(type: "varchar", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    DeliveryPersonId = table.Column<int>(type: "integer", nullable: false),
                    MotorcycleId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    ExpectedEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    Days = table.Column<short>(type: "smallint", nullable: false),
                    DailyRate = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_DeliveryPersons_DeliveryPersonId",
                        column: x => x.DeliveryPersonId,
                        principalTable: "DeliveryPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rentals_Motorcycles_MotorcycleId",
                        column: x => x.MotorcycleId,
                        principalTable: "Motorcycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CnhTypes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "A" },
                    { 2, "B" },
                    { 3, "AxB" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_DeliveryPersonId",
                table: "Rentals",
                column: "DeliveryPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_MotorcycleId",
                table: "Rentals",
                column: "MotorcycleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CnhTypes");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "DeliveryPersons");

            migrationBuilder.DropTable(
                name: "Motorcycles");
        }
    }
}
