using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KP.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DirectionsOfTravel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectionsOfTravel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KpiType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KpiType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasureType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasureType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Theme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitsOfMeasure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsOfMeasure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Measure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ThemeId = table.Column<int>(type: "int", nullable: false),
                    UnitsOfMeasureId = table.Column<int>(type: "int", nullable: false),
                    KpiTypeId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KPIType_KPITypeId",
                        column: x => x.KpiTypeId,
                        principalTable: "KpiType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Measure_UnitsOfMeasureId",
                        column: x => x.UnitsOfMeasureId,
                        principalTable: "UnitsOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Theme_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Theme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kpi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureId = table.Column<int>(type: "int", nullable: false),
                    Lead = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    UnitsOfMeasureId = table.Column<int>(type: "int", nullable: false),
                    ActualClosingPositionStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    ActualClosingPositionStartValue = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ActualClosingPositionEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    ActualClosingPositionEndValue = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ActualYTDPrevious = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ActualYTDCurrent = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TargetDate = table.Column<DateTime>(type: "date", nullable: true),
                    TargetValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ForecastDate = table.Column<DateTime>(type: "date", nullable: true),
                    ForecastValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DirectionsOfTravelId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kpi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DirectionsOfTravel_DirectionsOfTravelId",
                        column: x => x.DirectionsOfTravelId,
                        principalTable: "DirectionsOfTravel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Measure_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitsOfMeasure_UnitsOfMeasureId",
                        column: x => x.UnitsOfMeasureId,
                        principalTable: "UnitsOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kpi_DirectionsOfTravelId",
                table: "Kpi",
                column: "DirectionsOfTravelId");

            migrationBuilder.CreateIndex(
                name: "IX_Kpi_MeasureId",
                table: "Kpi",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Kpi_StatusId",
                table: "Kpi",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Kpi_UnitsOfMeasureId",
                table: "Kpi",
                column: "UnitsOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Measure_KpiTypeId",
                table: "Measure",
                column: "KpiTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Measure_ThemeId",
                table: "Measure",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Measure_UnitsOfMeasureId",
                table: "Measure",
                column: "UnitsOfMeasureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kpi");

            migrationBuilder.DropTable(
                name: "MeasureType");

            migrationBuilder.DropTable(
                name: "DirectionsOfTravel");

            migrationBuilder.DropTable(
                name: "Measure");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "KpiType");

            migrationBuilder.DropTable(
                name: "UnitsOfMeasure");

            migrationBuilder.DropTable(
                name: "Theme");
        }
    }
}
