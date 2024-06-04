using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSt_Postcode_API.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralLookups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISDefault = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralLookups", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PostcodeClassifications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostcodeClassifications", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Victoria"),
                    AbbreviatedName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Vic"),
                    ISTerritory = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PostcodeSpecificationMapper",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostcodeClassification_SAndPID = table.Column<int>(type: "int", nullable: true),
                    PostcodeClassification_HighSecurityID = table.Column<int>(type: "int", nullable: true),
                    PostcodeClassification_PCCategoryID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostcodeSpecificationMapper", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PostcodeSpecificationMapper_PostcodeClassifications_PostcodeClassification_HighSecurityID",
                        column: x => x.PostcodeClassification_HighSecurityID,
                        principalTable: "PostcodeClassifications",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PostcodeSpecificationMapper_PostcodeClassifications_PostcodeClassification_PCCategoryID",
                        column: x => x.PostcodeClassification_PCCategoryID,
                        principalTable: "PostcodeClassifications",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PostcodeSpecificationMapper_PostcodeClassifications_PostcodeClassification_SAndPID",
                        column: x => x.PostcodeClassification_SAndPID,
                        principalTable: "PostcodeClassifications",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Suburbs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Suburb_StateID = table.Column<int>(type: "int", nullable: true),
                    Suburb_LocationTypeID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suburbs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Suburbs_GeneralLookups_Suburb_LocationTypeID",
                        column: x => x.Suburb_LocationTypeID,
                        principalTable: "GeneralLookups",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Suburbs_States_Suburb_StateID",
                        column: x => x.Suburb_StateID,
                        principalTable: "States",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Postcodes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postcode_SuburbID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postcodes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Postcodes_Suburbs_Postcode_SuburbID",
                        column: x => x.Postcode_SuburbID,
                        principalTable: "Suburbs",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PostcodeClassificationMapper",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostcodeClassificationMapper_PostcodeClassificationID = table.Column<int>(type: "int", nullable: true),
                    PostcodeClassificationMapper_PostcodeID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostcodeClassificationMapper", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PostcodeClassificationMapper_PostcodeClassifications_PostcodeClassificationMapper_PostcodeClassificationID",
                        column: x => x.PostcodeClassificationMapper_PostcodeClassificationID,
                        principalTable: "PostcodeClassifications",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PostcodeClassificationMapper_Postcodes_PostcodeClassificationMapper_PostcodeID",
                        column: x => x.PostcodeClassificationMapper_PostcodeID,
                        principalTable: "Postcodes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PostcodeSuburbMapper",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostcodeSuburbMapper_PostcodeID = table.Column<int>(type: "int", nullable: false),
                    PostcodeSuburbMapper_SuburbID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostcodeSuburbMapper", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PostcodeSuburbMapper_Postcodes_PostcodeSuburbMapper_PostcodeID",
                        column: x => x.PostcodeSuburbMapper_PostcodeID,
                        principalTable: "Postcodes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostcodeSuburbMapper_Suburbs_PostcodeSuburbMapper_SuburbID",
                        column: x => x.PostcodeSuburbMapper_SuburbID,
                        principalTable: "Suburbs",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostcodeClassificationMapper_PostcodeClassificationMapper_PostcodeClassificationID",
                table: "PostcodeClassificationMapper",
                column: "PostcodeClassificationMapper_PostcodeClassificationID");

            migrationBuilder.CreateIndex(
                name: "IX_PostcodeClassificationMapper_PostcodeClassificationMapper_PostcodeID",
                table: "PostcodeClassificationMapper",
                column: "PostcodeClassificationMapper_PostcodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Postcodes_Postcode_SuburbID",
                table: "Postcodes",
                column: "Postcode_SuburbID");

            migrationBuilder.CreateIndex(
                name: "IX_PostcodeSpecificationMapper_PostcodeClassification_HighSecurityID",
                table: "PostcodeSpecificationMapper",
                column: "PostcodeClassification_HighSecurityID");

            migrationBuilder.CreateIndex(
                name: "IX_PostcodeSpecificationMapper_PostcodeClassification_PCCategoryID",
                table: "PostcodeSpecificationMapper",
                column: "PostcodeClassification_PCCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PostcodeSpecificationMapper_PostcodeClassification_SAndPID",
                table: "PostcodeSpecificationMapper",
                column: "PostcodeClassification_SAndPID");

            migrationBuilder.CreateIndex(
                name: "IX_PostcodeSuburbMapper_PostcodeSuburbMapper_PostcodeID",
                table: "PostcodeSuburbMapper",
                column: "PostcodeSuburbMapper_PostcodeID");

            migrationBuilder.CreateIndex(
                name: "IX_PostcodeSuburbMapper_PostcodeSuburbMapper_SuburbID",
                table: "PostcodeSuburbMapper",
                column: "PostcodeSuburbMapper_SuburbID");

            migrationBuilder.CreateIndex(
                name: "IX_Suburbs_Suburb_LocationTypeID",
                table: "Suburbs",
                column: "Suburb_LocationTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Suburbs_Suburb_StateID",
                table: "Suburbs",
                column: "Suburb_StateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostcodeClassificationMapper");

            migrationBuilder.DropTable(
                name: "PostcodeSpecificationMapper");

            migrationBuilder.DropTable(
                name: "PostcodeSuburbMapper");

            migrationBuilder.DropTable(
                name: "PostcodeClassifications");

            migrationBuilder.DropTable(
                name: "Postcodes");

            migrationBuilder.DropTable(
                name: "Suburbs");

            migrationBuilder.DropTable(
                name: "GeneralLookups");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
