using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Location.Service.Insfrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    RecordStatus = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedByUserGuid = table.Column<Guid>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedByUserGuid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AutoCodeParent = table.Column<string>(nullable: true),
                    AutoCodeOwn = table.Column<int>(nullable: false),
                    ManualCode = table.Column<string>(nullable: true),
                    ParentLocationId = table.Column<int>(nullable: true),
                    LocationTagId = table.Column<int>(nullable: true),
                    LocationLevelId = table.Column<int>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    Area = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    RecordStatus = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedByUserGuid = table.Column<Guid>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedByUserGuid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentLocationLevelId = table.Column<int>(nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    SystemId = table.Column<int>(nullable: true),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationLevel_LocationLevel_ParentLocationLevelId",
                        column: x => x.ParentLocationLevelId,
                        principalTable: "LocationLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationLevel_ParentLocationLevelId",
                table: "LocationLevel",
                column: "ParentLocationLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "LocationLevel");
        }
    }
}
