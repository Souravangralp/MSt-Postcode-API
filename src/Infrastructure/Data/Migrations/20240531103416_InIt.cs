using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductMatrix.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InIt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BorrowingEntityTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowingEntityTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BuilderTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuilderTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BusinessFinanceTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessFinanceTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CashOutTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashOutTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ConstructionTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CouncilZoningCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouncilZoningCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DefaultSettings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Property = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultSettings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DocTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GeneralLookUps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISArchived = table.Column<bool>(type: "bit", nullable: false),
                    ISDefault = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralLookUps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LandSizes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<double>(type: "float", nullable: false),
                    To = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandSizes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LoanToValueRatios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<double>(type: "float", nullable: false),
                    To = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanToValueRatios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NumeralClassifications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanAmountFrom = table.Column<double>(type: "float", nullable: false),
                    LoanAmountTo = table.Column<double>(type: "float", nullable: false),
                    NumeralType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeralClassifications", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OtherIncomeTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherIncomeTypes", x => x.ID);
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
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostcodeClassifications", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCatalogues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RuleDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISUltraPrimeI = table.Column<bool>(type: "bit", nullable: false),
                    ISUltraPrimeII = table.Column<bool>(type: "bit", nullable: false),
                    ISUltraPrimeIII = table.Column<bool>(type: "bit", nullable: false),
                    ISUltraPrimeIV = table.Column<bool>(type: "bit", nullable: false),
                    ISUltraPrimeV = table.Column<bool>(type: "bit", nullable: false),
                    ISSuperPrimeI = table.Column<bool>(type: "bit", nullable: false),
                    ISSuperPrimeII = table.Column<bool>(type: "bit", nullable: false),
                    ISSuperPrimeIII = table.Column<bool>(type: "bit", nullable: false),
                    ISSuperPrimeIV = table.Column<bool>(type: "bit", nullable: false),
                    ISSuperPrimeV = table.Column<bool>(type: "bit", nullable: false),
                    ISPremiumI = table.Column<bool>(type: "bit", nullable: false),
                    ISPremiumII = table.Column<bool>(type: "bit", nullable: false),
                    ISPremiumIII = table.Column<bool>(type: "bit", nullable: false),
                    ISPremiumIV = table.Column<bool>(type: "bit", nullable: false),
                    ISPremiumV = table.Column<bool>(type: "bit", nullable: false),
                    ISOptimaxI = table.Column<bool>(type: "bit", nullable: false),
                    ISOptimaxII = table.Column<bool>(type: "bit", nullable: false),
                    ISOptimaxIII = table.Column<bool>(type: "bit", nullable: false),
                    ISOptimaxIV = table.Column<bool>(type: "bit", nullable: false),
                    ISOptimaxV = table.Column<bool>(type: "bit", nullable: false),
                    ISTolerantI = table.Column<bool>(type: "bit", nullable: false),
                    ISTolerantII = table.Column<bool>(type: "bit", nullable: false),
                    ISTolerantIII = table.Column<bool>(type: "bit", nullable: false),
                    ISTolerantIV = table.Column<bool>(type: "bit", nullable: false),
                    ISTolerantV = table.Column<bool>(type: "bit", nullable: false),
                    ISProgressiveI = table.Column<bool>(type: "bit", nullable: false),
                    ISProgressiveII = table.Column<bool>(type: "bit", nullable: false),
                    ISProgressiveIII = table.Column<bool>(type: "bit", nullable: false),
                    ISProgressiveIV = table.Column<bool>(type: "bit", nullable: false),
                    ISProgressiveV = table.Column<bool>(type: "bit", nullable: false),
                    ISReceptiveI = table.Column<bool>(type: "bit", nullable: false),
                    ISReceptiveII = table.Column<bool>(type: "bit", nullable: false),
                    ISReceptiveIII = table.Column<bool>(type: "bit", nullable: false),
                    ISReceptiveIV = table.Column<bool>(type: "bit", nullable: false),
                    ISReceptiveV = table.Column<bool>(type: "bit", nullable: false),
                    ISLiberalI = table.Column<bool>(type: "bit", nullable: false),
                    ISLiberalII = table.Column<bool>(type: "bit", nullable: false),
                    ISLiberalIII = table.Column<bool>(type: "bit", nullable: false),
                    ISLiberalIV = table.Column<bool>(type: "bit", nullable: false),
                    ISLiberalV = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCatalogues", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RelocationServicings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelocationServicings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RenovationTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RenovationTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SelfEmployedClassifications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelfEmployedClassification_DocTypeID = table.Column<int>(type: "int", nullable: true),
                    MinimumTimeInMonths = table.Column<int>(type: "int", nullable: false),
                    MaximumTimeInMonths = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelfEmployedClassifications", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Victoria"),
                    AbbreivatedName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Vic"),
                    ISTerritory = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VacantLandCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacantLandCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentClassifications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmploymentClassification_CouncilZoningCategoryID = table.Column<int>(type: "int", nullable: true),
                    EmploymentStatusType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumExperienceOfWorkInMonths = table.Column<int>(type: "int", nullable: false),
                    MaximumExperienceOfWorkInMonths = table.Column<int>(type: "int", nullable: false),
                    ISSameLineOfWork = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentClassifications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmploymentClassifications_CouncilZoningCategories_EmploymentClassification_CouncilZoningCategoryID",
                        column: x => x.EmploymentClassification_CouncilZoningCategoryID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LandSizeClassifications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LandSizeClassification_CouncilZoningTypeID = table.Column<int>(type: "int", nullable: true),
                    From = table.Column<double>(type: "float", nullable: false),
                    To = table.Column<double>(type: "float", nullable: false),
                    HeedFulPoints = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandSizeClassifications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LandSizeClassifications_CouncilZoningCategories_LandSizeClassification_CouncilZoningTypeID",
                        column: x => x.LandSizeClassification_CouncilZoningTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AdditionalFeeDocTypeVariations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalFeeDocTypeVariation_DocTypeID = table.Column<int>(type: "int", nullable: true),
                    FormulaType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalFeeDocTypeVariations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdditionalFeeDocTypeVariations_DocTypes_AdditionalFeeDocTypeVariation_DocTypeID",
                        column: x => x.AdditionalFeeDocTypeVariation_DocTypeID,
                        principalTable: "DocTypes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationObjectiveClassifications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationObjectiveClassification_CouncilZoningTypeID = table.Column<int>(type: "int", nullable: true),
                    EquityType_GeneralLookUpID = table.Column<int>(type: "int", nullable: true),
                    UsageType_GeneralLookUpID = table.Column<int>(type: "int", nullable: true),
                    AwayBankType_GeneralLookUpID = table.Column<int>(type: "int", nullable: true),
                    ConsolidateForm = table.Column<int>(type: "int", nullable: true, comment: "How many loans have for consolidation."),
                    ConsolidateTo = table.Column<int>(type: "int", nullable: true),
                    HeedFulPoints = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationObjectiveClassifications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplicationObjectiveClassifications_CouncilZoningCategories_ApplicationObjectiveClassification_CouncilZoningTypeID",
                        column: x => x.ApplicationObjectiveClassification_CouncilZoningTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ApplicationObjectiveClassifications_GeneralLookUps_AwayBankType_GeneralLookUpID",
                        column: x => x.AwayBankType_GeneralLookUpID,
                        principalTable: "GeneralLookUps",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ApplicationObjectiveClassifications_GeneralLookUps_EquityType_GeneralLookUpID",
                        column: x => x.EquityType_GeneralLookUpID,
                        principalTable: "GeneralLookUps",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ApplicationObjectiveClassifications_GeneralLookUps_UsageType_GeneralLookUpID",
                        column: x => x.UsageType_GeneralLookUpID,
                        principalTable: "GeneralLookUps",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RulesFilters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilterType_GeneralLookUpID = table.Column<int>(type: "int", nullable: true),
                    RulesFilter_CouncilZoningTypeID = table.Column<int>(type: "int", nullable: true),
                    ParentRuleFilterID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RulesFilters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RulesFilters_CouncilZoningCategories_RulesFilter_CouncilZoningTypeID",
                        column: x => x.RulesFilter_CouncilZoningTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RulesFilters_GeneralLookUps_FilterType_GeneralLookUpID",
                        column: x => x.FilterType_GeneralLookUpID,
                        principalTable: "GeneralLookUps",
                        principalColumn: "ID");
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
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_ProductCategoryID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RangeFrom = table.Column<double>(type: "float", nullable: false),
                    RangeTo = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_Product_ProductCategoryID",
                        column: x => x.Product_ProductCategoryID,
                        principalTable: "ProductCategories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Postcodes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postcode_StateID = table.Column<int>(type: "int", nullable: true),
                    ISIsLand = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postcodes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Postcodes_States_Postcode_StateID",
                        column: x => x.Postcode_StateID,
                        principalTable: "States",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Suburbs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Suburb_SuburbStateID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuburbStateID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suburbs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Suburbs_States_SuburbStateID",
                        column: x => x.SuburbStateID,
                        principalTable: "States",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AdditionalFees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalFee_LoanToValueRatioID = table.Column<int>(type: "int", nullable: true),
                    AdditionalFee_DocTypeID = table.Column<int>(type: "int", nullable: true),
                    AdditionalFee_VacantLandCategoryID = table.Column<int>(type: "int", nullable: true),
                    AdditionalFee_LandSizeID = table.Column<int>(type: "int", nullable: true),
                    IncrementFee = table.Column<double>(type: "float", nullable: false),
                    FeeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalFees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdditionalFees_DocTypes_AdditionalFee_DocTypeID",
                        column: x => x.AdditionalFee_DocTypeID,
                        principalTable: "DocTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AdditionalFees_LandSizes_AdditionalFee_LandSizeID",
                        column: x => x.AdditionalFee_LandSizeID,
                        principalTable: "LandSizes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AdditionalFees_LoanToValueRatios_AdditionalFee_LoanToValueRatioID",
                        column: x => x.AdditionalFee_LoanToValueRatioID,
                        principalTable: "LoanToValueRatios",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AdditionalFees_VacantLandCategories_AdditionalFee_VacantLandCategoryID",
                        column: x => x.AdditionalFee_VacantLandCategoryID,
                        principalTable: "VacantLandCategories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ScenarioBuilders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScenarioBuilder_VacantLandCategoryID = table.Column<int>(type: "int", nullable: true),
                    ScenarioBuilder_RelocationServicingID = table.Column<int>(type: "int", nullable: true),
                    PCCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISOwnerOccupied = table.Column<bool>(type: "bit", nullable: false),
                    CouncilZoning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISSelectedMetro = table.Column<bool>(type: "bit", nullable: false),
                    ISNaturalPerson = table.Column<bool>(type: "bit", nullable: false),
                    ISHighDensity = table.Column<bool>(type: "bit", nullable: false),
                    FormulaType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScenarioBuilder_CouncilZoningCategoryID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScenarioBuilders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScenarioBuilders_CouncilZoningCategories_ScenarioBuilder_CouncilZoningCategoryID",
                        column: x => x.ScenarioBuilder_CouncilZoningCategoryID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ScenarioBuilders_RelocationServicings_ScenarioBuilder_RelocationServicingID",
                        column: x => x.ScenarioBuilder_RelocationServicingID,
                        principalTable: "RelocationServicings",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ScenarioBuilders_VacantLandCategories_ScenarioBuilder_VacantLandCategoryID",
                        column: x => x.ScenarioBuilder_VacantLandCategoryID,
                        principalTable: "VacantLandCategories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AgeCreditReportProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgeCreditReportProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    FromDays = table.Column<int>(type: "int", nullable: false),
                    ToDays = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeCreditReportProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AgeCreditReportProductSelectors_Products_AgeCreditReportProductSelector_ProductID",
                        column: x => x.AgeCreditReportProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationObjectiveProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationObjectiveProductSelector_ApplicationObjectiveClassificationID = table.Column<int>(type: "int", nullable: true),
                    ApplicationObjectiveProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationObjectiveProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplicationObjectiveProductSelectors_ApplicationObjectiveClassifications_ApplicationObjectiveProductSelector_ApplicationObje~",
                        column: x => x.ApplicationObjectiveProductSelector_ApplicationObjectiveClassificationID,
                        principalTable: "ApplicationObjectiveClassifications",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ApplicationObjectiveProductSelectors_Products_ApplicationObjectiveProductSelector_ProductID",
                        column: x => x.ApplicationObjectiveProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "BorrowingEntityProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorrowingEntityProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    BorrowingEntityProductSelector_BorrowingEntityTypeID = table.Column<int>(type: "int", nullable: true),
                    BorrowingEntityProductSelector_CouncilZoningTypeID = table.Column<int>(type: "int", nullable: true),
                    HeedfulPoints = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowingEntityProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BorrowingEntityProductSelectors_BorrowingEntityTypes_BorrowingEntityProductSelector_BorrowingEntityTypeID",
                        column: x => x.BorrowingEntityProductSelector_BorrowingEntityTypeID,
                        principalTable: "BorrowingEntityTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_BorrowingEntityProductSelectors_CouncilZoningCategories_BorrowingEntityProductSelector_CouncilZoningTypeID",
                        column: x => x.BorrowingEntityProductSelector_CouncilZoningTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_BorrowingEntityProductSelectors_Products_BorrowingEntityProductSelector_ProductID",
                        column: x => x.BorrowingEntityProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ButtonTypeProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ButtonTypeProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    ButtonTypeProductSelector_CouncilZoningTypeID = table.Column<int>(type: "int", nullable: true),
                    ButtonTypeProductSelector_GeneralLookUpID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ButtonTypeProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ButtonTypeProductSelectors_CouncilZoningCategories_ButtonTypeProductSelector_CouncilZoningTypeID",
                        column: x => x.ButtonTypeProductSelector_CouncilZoningTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ButtonTypeProductSelectors_GeneralLookUps_ButtonTypeProductSelector_GeneralLookUpID",
                        column: x => x.ButtonTypeProductSelector_GeneralLookUpID,
                        principalTable: "GeneralLookUps",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ButtonTypeProductSelectors_Products_ButtonTypeProductSelector_ProductID",
                        column: x => x.ButtonTypeProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CashOutProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashOutProductSelector_BusinessFinanceTypeID = table.Column<int>(type: "int", nullable: true),
                    CashOutProductSelector_CashOutTypeID = table.Column<int>(type: "int", nullable: true),
                    CashOutProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashOutProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CashOutProductSelectors_BusinessFinanceTypes_CashOutProductSelector_BusinessFinanceTypeID",
                        column: x => x.CashOutProductSelector_BusinessFinanceTypeID,
                        principalTable: "BusinessFinanceTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CashOutProductSelectors_CashOutTypes_CashOutProductSelector_CashOutTypeID",
                        column: x => x.CashOutProductSelector_CashOutTypeID,
                        principalTable: "CashOutTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CashOutProductSelectors_Products_CashOutProductSelector_ProductID",
                        column: x => x.CashOutProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ConstructionProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConstructionProductSelector_CouncilZoningTypeID = table.Column<int>(type: "int", nullable: true),
                    ConstructionProductSelector_ConstructionTypeID = table.Column<int>(type: "int", nullable: true),
                    ConstructionProductSelector_BuilderTypeID = table.Column<int>(type: "int", nullable: true),
                    ConstructionProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    ConstructionProductSelector_RenovationTypeID = table.Column<int>(type: "int", nullable: true),
                    ISGreenRated = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ConstructionProductSelectors_BuilderTypes_ConstructionProductSelector_BuilderTypeID",
                        column: x => x.ConstructionProductSelector_BuilderTypeID,
                        principalTable: "BuilderTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ConstructionProductSelectors_ConstructionTypes_ConstructionProductSelector_ConstructionTypeID",
                        column: x => x.ConstructionProductSelector_ConstructionTypeID,
                        principalTable: "ConstructionTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ConstructionProductSelectors_CouncilZoningCategories_ConstructionProductSelector_CouncilZoningTypeID",
                        column: x => x.ConstructionProductSelector_CouncilZoningTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ConstructionProductSelectors_Products_ConstructionProductSelector_ProductID",
                        column: x => x.ConstructionProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ConstructionProductSelectors_RenovationTypes_ConstructionProductSelector_RenovationTypeID",
                        column: x => x.ConstructionProductSelector_RenovationTypeID,
                        principalTable: "RenovationTypes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DefaultFees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormulaType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultFee_DocTypeID = table.Column<int>(type: "int", nullable: true),
                    DefaultFee_LoanToValueRatioID = table.Column<int>(type: "int", nullable: true),
                    DefaultFee_ProductID = table.Column<int>(type: "int", nullable: true),
                    ApplicationFee = table.Column<double>(type: "float", nullable: true),
                    AnnualFee = table.Column<double>(type: "float", nullable: true),
                    RiskFee = table.Column<double>(type: "float", nullable: true),
                    EstablishmentFee = table.Column<double>(type: "float", nullable: true),
                    SettlementFee = table.Column<double>(type: "float", nullable: true),
                    DischargeFee = table.Column<double>(type: "float", nullable: true),
                    RateLoadingFee = table.Column<double>(type: "float", nullable: true),
                    DeedOfPriorityFee = table.Column<double>(type: "float", nullable: true),
                    ExpressFee = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultFees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DefaultFees_DocTypes_DefaultFee_DocTypeID",
                        column: x => x.DefaultFee_DocTypeID,
                        principalTable: "DocTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DefaultFees_LoanToValueRatios_DefaultFee_LoanToValueRatioID",
                        column: x => x.DefaultFee_LoanToValueRatioID,
                        principalTable: "LoanToValueRatios",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DefaultFees_Products_DefaultFee_ProductID",
                        column: x => x.DefaultFee_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DocTypeProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocTypeProductSelector_DocTypeID = table.Column<int>(type: "int", nullable: true),
                    DocTypeProductSelector_CouncilZoningTypeID = table.Column<int>(type: "int", nullable: true),
                    DocTypeProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    MinimumLoanTermInYears = table.Column<int>(type: "int", nullable: false),
                    MaximumLoanTermInYears = table.Column<int>(type: "int", nullable: false),
                    HeedfulPoints = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocTypeProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DocTypeProductSelectors_CouncilZoningCategories_DocTypeProductSelector_CouncilZoningTypeID",
                        column: x => x.DocTypeProductSelector_CouncilZoningTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DocTypeProductSelectors_DocTypes_DocTypeProductSelector_DocTypeID",
                        column: x => x.DocTypeProductSelector_DocTypeID,
                        principalTable: "DocTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DocTypeProductSelectors_Products_DocTypeProductSelector_ProductID",
                        column: x => x.DocTypeProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DwellingsProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DwellingsProductSelector_CouncilZoningCategoryTypeID = table.Column<int>(type: "int", nullable: true),
                    DwellingsProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    PCCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DwellingCount = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellingsProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DwellingsProductSelectors_CouncilZoningCategories_DwellingsProductSelector_CouncilZoningCategoryTypeID",
                        column: x => x.DwellingsProductSelector_CouncilZoningCategoryTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DwellingsProductSelectors_Products_DwellingsProductSelector_ProductID",
                        column: x => x.DwellingsProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployerClassificationProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerClassificationProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    EmployerClassificationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerClassificationProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployerClassificationProductSelectors_Products_EmployerClassificationProductSelector_ProductID",
                        column: x => x.EmployerClassificationProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "EmploymentClassificationProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmploymentClassificationProductSelector_EmploymentClassificationID = table.Column<int>(type: "int", nullable: true),
                    EmploymentClassificationProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentClassificationProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmploymentClassificationProductSelectors_EmploymentClassifications_EmploymentClassificationProductSelector_EmploymentClassif~",
                        column: x => x.EmploymentClassificationProductSelector_EmploymentClassificationID,
                        principalTable: "EmploymentClassifications",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EmploymentClassificationProductSelectors_Products_EmploymentClassificationProductSelector_ProductID",
                        column: x => x.EmploymentClassificationProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FacilityTypeProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityTypeProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    FacilityTypeProductSelector_CouncilZoningTypeID = table.Column<int>(type: "int", nullable: true),
                    FacilityTypeProductSelector_GeneralLookUpID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityTypeProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FacilityTypeProductSelectors_CouncilZoningCategories_FacilityTypeProductSelector_CouncilZoningTypeID",
                        column: x => x.FacilityTypeProductSelector_CouncilZoningTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FacilityTypeProductSelectors_GeneralLookUps_FacilityTypeProductSelector_GeneralLookUpID",
                        column: x => x.FacilityTypeProductSelector_GeneralLookUpID,
                        principalTable: "GeneralLookUps",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FacilityTypeProductSelectors_Products_FacilityTypeProductSelector_ProductID",
                        column: x => x.FacilityTypeProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "GuidedByTypeProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuidedByTypeProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    GuidedByTypeProductSelector_GeneralLookUpID = table.Column<int>(type: "int", nullable: true),
                    GuidedByTypeProductSelector_CouncilZoningTypeID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidedByTypeProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GuidedByTypeProductSelectors_CouncilZoningCategories_GuidedByTypeProductSelector_CouncilZoningTypeID",
                        column: x => x.GuidedByTypeProductSelector_CouncilZoningTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GuidedByTypeProductSelectors_GeneralLookUps_GuidedByTypeProductSelector_GeneralLookUpID",
                        column: x => x.GuidedByTypeProductSelector_GeneralLookUpID,
                        principalTable: "GeneralLookUps",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GuidedByTypeProductSelectors_Products_GuidedByTypeProductSelector_ProductID",
                        column: x => x.GuidedByTypeProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "HeedFullPointTypeProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeedFullPointTypeProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    HeedFullPointTypeProductSelector_CouncilZoningTypeID = table.Column<int>(type: "int", nullable: true),
                    HeedFullPointTypeProductSelector_GeneralLookUpID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeedFullPointTypeProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HeedFullPointTypeProductSelectors_CouncilZoningCategories_HeedFullPointTypeProductSelector_CouncilZoningTypeID",
                        column: x => x.HeedFullPointTypeProductSelector_CouncilZoningTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_HeedFullPointTypeProductSelectors_GeneralLookUps_HeedFullPointTypeProductSelector_GeneralLookUpID",
                        column: x => x.HeedFullPointTypeProductSelector_GeneralLookUpID,
                        principalTable: "GeneralLookUps",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_HeedFullPointTypeProductSelectors_Products_HeedFullPointTypeProductSelector_ProductID",
                        column: x => x.HeedFullPointTypeProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LandSizeProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LandSizeProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    LandSizeProductSelector_LandSizeClassificationID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandSizeProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LandSizeProductSelectors_LandSizeClassifications_LandSizeProductSelector_LandSizeClassificationID",
                        column: x => x.LandSizeProductSelector_LandSizeClassificationID,
                        principalTable: "LandSizeClassifications",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_LandSizeProductSelectors_Products_LandSizeProductSelector_ProductID",
                        column: x => x.LandSizeProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LoanAmountProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanAmountProductSelector_DocTypeID = table.Column<int>(type: "int", nullable: true),
                    LoanAmountProductSelector_CouncilZoningTypeID = table.Column<int>(type: "int", nullable: true),
                    LoanAmountProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    LoanType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanAmountProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LoanAmountProductSelectors_CouncilZoningCategories_LoanAmountProductSelector_CouncilZoningTypeID",
                        column: x => x.LoanAmountProductSelector_CouncilZoningTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_LoanAmountProductSelectors_DocTypes_LoanAmountProductSelector_DocTypeID",
                        column: x => x.LoanAmountProductSelector_DocTypeID,
                        principalTable: "DocTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_LoanAmountProductSelectors_Products_LoanAmountProductSelector_ProductID",
                        column: x => x.LoanAmountProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LvrProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LvrProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    MaximumLVR = table.Column<double>(type: "float", nullable: false),
                    ResidencyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LvrProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LvrProductSelectors_Products_LvrProductSelector_ProductID",
                        column: x => x.LvrProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatusProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaritalStatusProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    MaritalStatusProductSelector_CouncilZoningCategoryTypeID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatusProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MaritalStatusProductSelectors_CouncilZoningCategories_MaritalStatusProductSelector_CouncilZoningCategoryTypeID",
                        column: x => x.MaritalStatusProductSelector_CouncilZoningCategoryTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_MaritalStatusProductSelectors_Products_MaritalStatusProductSelector_ProductID",
                        column: x => x.MaritalStatusProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "NaturalPersonAgeProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NaturalPersonAgeProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    NaturalPersonAgeProductSelector_CouncilZoningTypeID = table.Column<int>(type: "int", nullable: true),
                    MinimumAge = table.Column<int>(type: "int", nullable: false),
                    MaximumAge = table.Column<int>(type: "int", nullable: false),
                    HeedfulPoints = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalPersonAgeProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NaturalPersonAgeProductSelectors_CouncilZoningCategories_NaturalPersonAgeProductSelector_CouncilZoningTypeID",
                        column: x => x.NaturalPersonAgeProductSelector_CouncilZoningTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_NaturalPersonAgeProductSelectors_Products_NaturalPersonAgeProductSelector_ProductID",
                        column: x => x.NaturalPersonAgeProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OtherIncomeTypeProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OtherIncomeTypeProductSelector_CouncilZoningCategoryTypeID = table.Column<int>(type: "int", nullable: true),
                    OtherIncomeTypeProductSelector_OtherIncomeTypeID = table.Column<int>(type: "int", nullable: true),
                    OtherIncomeTypeProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherIncomeTypeProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OtherIncomeTypeProductSelectors_CouncilZoningCategories_OtherIncomeTypeProductSelector_CouncilZoningCategoryTypeID",
                        column: x => x.OtherIncomeTypeProductSelector_CouncilZoningCategoryTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OtherIncomeTypeProductSelectors_OtherIncomeTypes_OtherIncomeTypeProductSelector_OtherIncomeTypeID",
                        column: x => x.OtherIncomeTypeProductSelector_OtherIncomeTypeID,
                        principalTable: "OtherIncomeTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OtherIncomeTypeProductSelectors_Products_OtherIncomeTypeProductSelector_ProductID",
                        column: x => x.OtherIncomeTypeProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PostcodeProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostcodeProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    PostcodeProductSelector_PostcodeSpecificationMapperID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostcodeProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PostcodeProductSelectors_PostcodeSpecificationMapper_PostcodeProductSelector_PostcodeSpecificationMapperID",
                        column: x => x.PostcodeProductSelector_PostcodeSpecificationMapperID,
                        principalTable: "PostcodeSpecificationMapper",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PostcodeProductSelectors_Products_PostcodeProductSelector_ProductID",
                        column: x => x.PostcodeProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PotentialImpactfulConsiderationProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PotentialImpactfulConsiderationProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PotentialImpactfulConsiderationProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PotentialImpactfulConsiderationProductSelectors_Products_PotentialImpactfulConsiderationProductSelector_ProductID",
                        column: x => x.PotentialImpactfulConsiderationProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ProductFeeLVRRates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductFeeLVRRate_ProductID = table.Column<int>(type: "int", nullable: true),
                    ProductFeeLVRRate_DocTypeID = table.Column<int>(type: "int", nullable: true),
                    FeeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LVRFrom = table.Column<double>(type: "float", nullable: false, comment: "LVR means loan value ratio"),
                    LVRTo = table.Column<double>(type: "float", nullable: false),
                    RatePercentIncrementDecrement = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeeLVRRates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductFeeLVRRates_DocTypes_ProductFeeLVRRate_DocTypeID",
                        column: x => x.ProductFeeLVRRate_DocTypeID,
                        principalTable: "DocTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProductFeeLVRRates_Products_ProductFeeLVRRate_ProductID",
                        column: x => x.ProductFeeLVRRate_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseTypeProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseTypeProductSelector_DocTypeID = table.Column<int>(type: "int", nullable: true),
                    PurchaseTypeProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    PurchaseTypeProductSelector_CouncilZoningTypeID = table.Column<int>(type: "int", nullable: true),
                    OccupancyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumLVR = table.Column<double>(type: "float", nullable: false),
                    MaximumLVR = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseTypeProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PurchaseTypeProductSelectors_CouncilZoningCategories_PurchaseTypeProductSelector_CouncilZoningTypeID",
                        column: x => x.PurchaseTypeProductSelector_CouncilZoningTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PurchaseTypeProductSelectors_DocTypes_PurchaseTypeProductSelector_DocTypeID",
                        column: x => x.PurchaseTypeProductSelector_DocTypeID,
                        principalTable: "DocTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PurchaseTypeProductSelectors_Products_PurchaseTypeProductSelector_ProductID",
                        column: x => x.PurchaseTypeProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RepaymentTypeProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepaymentTypeProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    RepaymentTypeProductSelector_CouncilZoningTypeID = table.Column<int>(type: "int", nullable: true),
                    RepaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RateType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeInYears = table.Column<int>(type: "int", nullable: false),
                    HeedfulPoints = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepaymentTypeProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RepaymentTypeProductSelectors_CouncilZoningCategories_RepaymentTypeProductSelector_CouncilZoningTypeID",
                        column: x => x.RepaymentTypeProductSelector_CouncilZoningTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RepaymentTypeProductSelectors_Products_RepaymentTypeProductSelector_ProductID",
                        column: x => x.RepaymentTypeProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SecurityTypeProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecurityTypeProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    SecurityTypeProductSelector_GeneralLookUpID = table.Column<int>(type: "int", nullable: true),
                    SecurityTypeProductSelector_CouncilZoningTypeID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityTypeProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SecurityTypeProductSelectors_CouncilZoningCategories_SecurityTypeProductSelector_CouncilZoningTypeID",
                        column: x => x.SecurityTypeProductSelector_CouncilZoningTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SecurityTypeProductSelectors_GeneralLookUps_SecurityTypeProductSelector_GeneralLookUpID",
                        column: x => x.SecurityTypeProductSelector_GeneralLookUpID,
                        principalTable: "GeneralLookUps",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SecurityTypeProductSelectors_Products_SecurityTypeProductSelector_ProductID",
                        column: x => x.SecurityTypeProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SelfEmployedClassificationProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelfEmployedClassificationProductSelector_SelfEmployedClassificationID = table.Column<int>(type: "int", nullable: true),
                    SelfEmployedClassificationProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelfEmployedClassificationProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SelfEmployedClassificationProductSelectors_Products_SelfEmployedClassificationProductSelector_ProductID",
                        column: x => x.SelfEmployedClassificationProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SelfEmployedClassificationProductSelectors_SelfEmployedClassifications_SelfEmployedClassificationProductSelector_SelfEmploye~",
                        column: x => x.SelfEmployedClassificationProductSelector_SelfEmployedClassificationID,
                        principalTable: "SelfEmployedClassifications",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypeProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTypeProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    ServiceTypeProductSelector_CouncilZoningTypeID = table.Column<int>(type: "int", nullable: true),
                    ServiceTypeProductSelector_GeneralLookUpID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypeProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServiceTypeProductSelectors_CouncilZoningCategories_ServiceTypeProductSelector_CouncilZoningTypeID",
                        column: x => x.ServiceTypeProductSelector_CouncilZoningTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ServiceTypeProductSelectors_GeneralLookUps_ServiceTypeProductSelector_GeneralLookUpID",
                        column: x => x.ServiceTypeProductSelector_GeneralLookUpID,
                        principalTable: "GeneralLookUps",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ServiceTypeProductSelectors_Products_ServiceTypeProductSelector_ProductID",
                        column: x => x.ServiceTypeProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TitleTypeProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleTypeProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    TitleTypeProductSelector_CouncilZoningTypeID = table.Column<int>(type: "int", nullable: true),
                    TitleTypeProductSelector_GeneralLookUpID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleTypeProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TitleTypeProductSelectors_CouncilZoningCategories_TitleTypeProductSelector_CouncilZoningTypeID",
                        column: x => x.TitleTypeProductSelector_CouncilZoningTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TitleTypeProductSelectors_GeneralLookUps_TitleTypeProductSelector_GeneralLookUpID",
                        column: x => x.TitleTypeProductSelector_GeneralLookUpID,
                        principalTable: "GeneralLookUps",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TitleTypeProductSelectors_Products_TitleTypeProductSelector_ProductID",
                        column: x => x.TitleTypeProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UnitsApartmentProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitsApartmentProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    LivingAreaFrom = table.Column<double>(type: "float", nullable: false),
                    LivingAreaTo = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsApartmentProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UnitsApartmentProductSelectors_Products_UnitsApartmentProductSelector_ProductID",
                        column: x => x.UnitsApartmentProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UsageTypeProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsageTypeProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    UsageTypeProductSelector_CouncilZoningTypeID = table.Column<int>(type: "int", nullable: true),
                    UsageTypeProductSelector_GeneralLookUpID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsageTypeProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsageTypeProductSelectors_CouncilZoningCategories_UsageTypeProductSelector_CouncilZoningTypeID",
                        column: x => x.UsageTypeProductSelector_CouncilZoningTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_UsageTypeProductSelectors_GeneralLookUps_UsageTypeProductSelector_GeneralLookUpID",
                        column: x => x.UsageTypeProductSelector_GeneralLookUpID,
                        principalTable: "GeneralLookUps",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_UsageTypeProductSelectors_Products_UsageTypeProductSelector_ProductID",
                        column: x => x.UsageTypeProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ZoningTypeProductSelectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoningTypeProductSelector_StateID = table.Column<int>(type: "int", nullable: true),
                    ZoningTypeProductSelector_ProductID = table.Column<int>(type: "int", nullable: true),
                    ZoningTypeProductSelector_CouncilZoningTypeID = table.Column<int>(type: "int", nullable: true),
                    ZoningTypeProductSelector_CouncilZoningCategoryID = table.Column<int>(type: "int", nullable: true),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoningTypeProductSelectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ZoningTypeProductSelectors_CouncilZoningCategories_ZoningTypeProductSelector_CouncilZoningCategoryID",
                        column: x => x.ZoningTypeProductSelector_CouncilZoningCategoryID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ZoningTypeProductSelectors_CouncilZoningCategories_ZoningTypeProductSelector_CouncilZoningTypeID",
                        column: x => x.ZoningTypeProductSelector_CouncilZoningTypeID,
                        principalTable: "CouncilZoningCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ZoningTypeProductSelectors_Products_ZoningTypeProductSelector_ProductID",
                        column: x => x.ZoningTypeProductSelector_ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ZoningTypeProductSelectors_States_ZoningTypeProductSelector_StateID",
                        column: x => x.ZoningTypeProductSelector_StateID,
                        principalTable: "States",
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
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    ISIsLand = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                name: "IX_AdditionalFeeDocTypeVariations_AdditionalFeeDocTypeVariation_DocTypeID",
                table: "AdditionalFeeDocTypeVariations",
                column: "AdditionalFeeDocTypeVariation_DocTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalFees_AdditionalFee_DocTypeID",
                table: "AdditionalFees",
                column: "AdditionalFee_DocTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalFees_AdditionalFee_LandSizeID",
                table: "AdditionalFees",
                column: "AdditionalFee_LandSizeID");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalFees_AdditionalFee_LoanToValueRatioID",
                table: "AdditionalFees",
                column: "AdditionalFee_LoanToValueRatioID");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalFees_AdditionalFee_VacantLandCategoryID",
                table: "AdditionalFees",
                column: "AdditionalFee_VacantLandCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_AgeCreditReportProductSelectors_AgeCreditReportProductSelector_ProductID",
                table: "AgeCreditReportProductSelectors",
                column: "AgeCreditReportProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationObjectiveClassifications_ApplicationObjectiveClassification_CouncilZoningTypeID",
                table: "ApplicationObjectiveClassifications",
                column: "ApplicationObjectiveClassification_CouncilZoningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationObjectiveClassifications_AwayBankType_GeneralLookUpID",
                table: "ApplicationObjectiveClassifications",
                column: "AwayBankType_GeneralLookUpID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationObjectiveClassifications_EquityType_GeneralLookUpID",
                table: "ApplicationObjectiveClassifications",
                column: "EquityType_GeneralLookUpID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationObjectiveClassifications_UsageType_GeneralLookUpID",
                table: "ApplicationObjectiveClassifications",
                column: "UsageType_GeneralLookUpID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationObjectiveProductSelectors_ApplicationObjectiveProductSelector_ApplicationObjectiveClassificationID",
                table: "ApplicationObjectiveProductSelectors",
                column: "ApplicationObjectiveProductSelector_ApplicationObjectiveClassificationID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationObjectiveProductSelectors_ApplicationObjectiveProductSelector_ProductID",
                table: "ApplicationObjectiveProductSelectors",
                column: "ApplicationObjectiveProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingEntityProductSelectors_BorrowingEntityProductSelector_BorrowingEntityTypeID",
                table: "BorrowingEntityProductSelectors",
                column: "BorrowingEntityProductSelector_BorrowingEntityTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingEntityProductSelectors_BorrowingEntityProductSelector_CouncilZoningTypeID",
                table: "BorrowingEntityProductSelectors",
                column: "BorrowingEntityProductSelector_CouncilZoningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingEntityProductSelectors_BorrowingEntityProductSelector_ProductID",
                table: "BorrowingEntityProductSelectors",
                column: "BorrowingEntityProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ButtonTypeProductSelectors_ButtonTypeProductSelector_CouncilZoningTypeID",
                table: "ButtonTypeProductSelectors",
                column: "ButtonTypeProductSelector_CouncilZoningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ButtonTypeProductSelectors_ButtonTypeProductSelector_GeneralLookUpID",
                table: "ButtonTypeProductSelectors",
                column: "ButtonTypeProductSelector_GeneralLookUpID");

            migrationBuilder.CreateIndex(
                name: "IX_ButtonTypeProductSelectors_ButtonTypeProductSelector_ProductID",
                table: "ButtonTypeProductSelectors",
                column: "ButtonTypeProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_CashOutProductSelectors_CashOutProductSelector_BusinessFinanceTypeID",
                table: "CashOutProductSelectors",
                column: "CashOutProductSelector_BusinessFinanceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CashOutProductSelectors_CashOutProductSelector_CashOutTypeID",
                table: "CashOutProductSelectors",
                column: "CashOutProductSelector_CashOutTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CashOutProductSelectors_CashOutProductSelector_ProductID",
                table: "CashOutProductSelectors",
                column: "CashOutProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionProductSelectors_ConstructionProductSelector_BuilderTypeID",
                table: "ConstructionProductSelectors",
                column: "ConstructionProductSelector_BuilderTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionProductSelectors_ConstructionProductSelector_ConstructionTypeID",
                table: "ConstructionProductSelectors",
                column: "ConstructionProductSelector_ConstructionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionProductSelectors_ConstructionProductSelector_CouncilZoningTypeID",
                table: "ConstructionProductSelectors",
                column: "ConstructionProductSelector_CouncilZoningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionProductSelectors_ConstructionProductSelector_ProductID",
                table: "ConstructionProductSelectors",
                column: "ConstructionProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionProductSelectors_ConstructionProductSelector_RenovationTypeID",
                table: "ConstructionProductSelectors",
                column: "ConstructionProductSelector_RenovationTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultFees_DefaultFee_DocTypeID",
                table: "DefaultFees",
                column: "DefaultFee_DocTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultFees_DefaultFee_LoanToValueRatioID",
                table: "DefaultFees",
                column: "DefaultFee_LoanToValueRatioID");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultFees_DefaultFee_ProductID",
                table: "DefaultFees",
                column: "DefaultFee_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_DocTypeProductSelectors_DocTypeProductSelector_CouncilZoningTypeID",
                table: "DocTypeProductSelectors",
                column: "DocTypeProductSelector_CouncilZoningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_DocTypeProductSelectors_DocTypeProductSelector_DocTypeID",
                table: "DocTypeProductSelectors",
                column: "DocTypeProductSelector_DocTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_DocTypeProductSelectors_DocTypeProductSelector_ProductID",
                table: "DocTypeProductSelectors",
                column: "DocTypeProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_DwellingsProductSelectors_DwellingsProductSelector_CouncilZoningCategoryTypeID",
                table: "DwellingsProductSelectors",
                column: "DwellingsProductSelector_CouncilZoningCategoryTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_DwellingsProductSelectors_DwellingsProductSelector_ProductID",
                table: "DwellingsProductSelectors",
                column: "DwellingsProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployerClassificationProductSelectors_EmployerClassificationProductSelector_ProductID",
                table: "EmployerClassificationProductSelectors",
                column: "EmployerClassificationProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentClassificationProductSelectors_EmploymentClassificationProductSelector_EmploymentClassificationID",
                table: "EmploymentClassificationProductSelectors",
                column: "EmploymentClassificationProductSelector_EmploymentClassificationID");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentClassificationProductSelectors_EmploymentClassificationProductSelector_ProductID",
                table: "EmploymentClassificationProductSelectors",
                column: "EmploymentClassificationProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentClassifications_EmploymentClassification_CouncilZoningCategoryID",
                table: "EmploymentClassifications",
                column: "EmploymentClassification_CouncilZoningCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityTypeProductSelectors_FacilityTypeProductSelector_CouncilZoningTypeID",
                table: "FacilityTypeProductSelectors",
                column: "FacilityTypeProductSelector_CouncilZoningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityTypeProductSelectors_FacilityTypeProductSelector_GeneralLookUpID",
                table: "FacilityTypeProductSelectors",
                column: "FacilityTypeProductSelector_GeneralLookUpID");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityTypeProductSelectors_FacilityTypeProductSelector_ProductID",
                table: "FacilityTypeProductSelectors",
                column: "FacilityTypeProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_GuidedByTypeProductSelectors_GuidedByTypeProductSelector_CouncilZoningTypeID",
                table: "GuidedByTypeProductSelectors",
                column: "GuidedByTypeProductSelector_CouncilZoningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_GuidedByTypeProductSelectors_GuidedByTypeProductSelector_GeneralLookUpID",
                table: "GuidedByTypeProductSelectors",
                column: "GuidedByTypeProductSelector_GeneralLookUpID");

            migrationBuilder.CreateIndex(
                name: "IX_GuidedByTypeProductSelectors_GuidedByTypeProductSelector_ProductID",
                table: "GuidedByTypeProductSelectors",
                column: "GuidedByTypeProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_HeedFullPointTypeProductSelectors_HeedFullPointTypeProductSelector_CouncilZoningTypeID",
                table: "HeedFullPointTypeProductSelectors",
                column: "HeedFullPointTypeProductSelector_CouncilZoningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_HeedFullPointTypeProductSelectors_HeedFullPointTypeProductSelector_GeneralLookUpID",
                table: "HeedFullPointTypeProductSelectors",
                column: "HeedFullPointTypeProductSelector_GeneralLookUpID");

            migrationBuilder.CreateIndex(
                name: "IX_HeedFullPointTypeProductSelectors_HeedFullPointTypeProductSelector_ProductID",
                table: "HeedFullPointTypeProductSelectors",
                column: "HeedFullPointTypeProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_LandSizeClassifications_LandSizeClassification_CouncilZoningTypeID",
                table: "LandSizeClassifications",
                column: "LandSizeClassification_CouncilZoningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_LandSizeProductSelectors_LandSizeProductSelector_LandSizeClassificationID",
                table: "LandSizeProductSelectors",
                column: "LandSizeProductSelector_LandSizeClassificationID");

            migrationBuilder.CreateIndex(
                name: "IX_LandSizeProductSelectors_LandSizeProductSelector_ProductID",
                table: "LandSizeProductSelectors",
                column: "LandSizeProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanAmountProductSelectors_LoanAmountProductSelector_CouncilZoningTypeID",
                table: "LoanAmountProductSelectors",
                column: "LoanAmountProductSelector_CouncilZoningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanAmountProductSelectors_LoanAmountProductSelector_DocTypeID",
                table: "LoanAmountProductSelectors",
                column: "LoanAmountProductSelector_DocTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanAmountProductSelectors_LoanAmountProductSelector_ProductID",
                table: "LoanAmountProductSelectors",
                column: "LoanAmountProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_LvrProductSelectors_LvrProductSelector_ProductID",
                table: "LvrProductSelectors",
                column: "LvrProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_MaritalStatusProductSelectors_MaritalStatusProductSelector_CouncilZoningCategoryTypeID",
                table: "MaritalStatusProductSelectors",
                column: "MaritalStatusProductSelector_CouncilZoningCategoryTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_MaritalStatusProductSelectors_MaritalStatusProductSelector_ProductID",
                table: "MaritalStatusProductSelectors",
                column: "MaritalStatusProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPersonAgeProductSelectors_NaturalPersonAgeProductSelector_CouncilZoningTypeID",
                table: "NaturalPersonAgeProductSelectors",
                column: "NaturalPersonAgeProductSelector_CouncilZoningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPersonAgeProductSelectors_NaturalPersonAgeProductSelector_ProductID",
                table: "NaturalPersonAgeProductSelectors",
                column: "NaturalPersonAgeProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_OtherIncomeTypeProductSelectors_OtherIncomeTypeProductSelector_CouncilZoningCategoryTypeID",
                table: "OtherIncomeTypeProductSelectors",
                column: "OtherIncomeTypeProductSelector_CouncilZoningCategoryTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_OtherIncomeTypeProductSelectors_OtherIncomeTypeProductSelector_OtherIncomeTypeID",
                table: "OtherIncomeTypeProductSelectors",
                column: "OtherIncomeTypeProductSelector_OtherIncomeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_OtherIncomeTypeProductSelectors_OtherIncomeTypeProductSelector_ProductID",
                table: "OtherIncomeTypeProductSelectors",
                column: "OtherIncomeTypeProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_PostcodeClassificationMapper_PostcodeClassificationMapper_PostcodeClassificationID",
                table: "PostcodeClassificationMapper",
                column: "PostcodeClassificationMapper_PostcodeClassificationID");

            migrationBuilder.CreateIndex(
                name: "IX_PostcodeClassificationMapper_PostcodeClassificationMapper_PostcodeID",
                table: "PostcodeClassificationMapper",
                column: "PostcodeClassificationMapper_PostcodeID");

            migrationBuilder.CreateIndex(
                name: "IX_PostcodeProductSelectors_PostcodeProductSelector_PostcodeSpecificationMapperID",
                table: "PostcodeProductSelectors",
                column: "PostcodeProductSelector_PostcodeSpecificationMapperID");

            migrationBuilder.CreateIndex(
                name: "IX_PostcodeProductSelectors_PostcodeProductSelector_ProductID",
                table: "PostcodeProductSelectors",
                column: "PostcodeProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Postcodes_Postcode_StateID",
                table: "Postcodes",
                column: "Postcode_StateID");

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
                name: "IX_PotentialImpactfulConsiderationProductSelectors_PotentialImpactfulConsiderationProductSelector_ProductID",
                table: "PotentialImpactfulConsiderationProductSelectors",
                column: "PotentialImpactfulConsiderationProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeeLVRRates_ProductFeeLVRRate_DocTypeID",
                table: "ProductFeeLVRRates",
                column: "ProductFeeLVRRate_DocTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeeLVRRates_ProductFeeLVRRate_ProductID",
                table: "ProductFeeLVRRates",
                column: "ProductFeeLVRRate_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Product_ProductCategoryID",
                table: "Products",
                column: "Product_ProductCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTypeProductSelectors_PurchaseTypeProductSelector_CouncilZoningTypeID",
                table: "PurchaseTypeProductSelectors",
                column: "PurchaseTypeProductSelector_CouncilZoningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTypeProductSelectors_PurchaseTypeProductSelector_DocTypeID",
                table: "PurchaseTypeProductSelectors",
                column: "PurchaseTypeProductSelector_DocTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTypeProductSelectors_PurchaseTypeProductSelector_ProductID",
                table: "PurchaseTypeProductSelectors",
                column: "PurchaseTypeProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_RepaymentTypeProductSelectors_RepaymentTypeProductSelector_CouncilZoningTypeID",
                table: "RepaymentTypeProductSelectors",
                column: "RepaymentTypeProductSelector_CouncilZoningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RepaymentTypeProductSelectors_RepaymentTypeProductSelector_ProductID",
                table: "RepaymentTypeProductSelectors",
                column: "RepaymentTypeProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_RulesFilters_FilterType_GeneralLookUpID",
                table: "RulesFilters",
                column: "FilterType_GeneralLookUpID");

            migrationBuilder.CreateIndex(
                name: "IX_RulesFilters_RulesFilter_CouncilZoningTypeID",
                table: "RulesFilters",
                column: "RulesFilter_CouncilZoningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ScenarioBuilders_ScenarioBuilder_CouncilZoningCategoryID",
                table: "ScenarioBuilders",
                column: "ScenarioBuilder_CouncilZoningCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ScenarioBuilders_ScenarioBuilder_RelocationServicingID",
                table: "ScenarioBuilders",
                column: "ScenarioBuilder_RelocationServicingID");

            migrationBuilder.CreateIndex(
                name: "IX_ScenarioBuilders_ScenarioBuilder_VacantLandCategoryID",
                table: "ScenarioBuilders",
                column: "ScenarioBuilder_VacantLandCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityTypeProductSelectors_SecurityTypeProductSelector_CouncilZoningTypeID",
                table: "SecurityTypeProductSelectors",
                column: "SecurityTypeProductSelector_CouncilZoningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityTypeProductSelectors_SecurityTypeProductSelector_GeneralLookUpID",
                table: "SecurityTypeProductSelectors",
                column: "SecurityTypeProductSelector_GeneralLookUpID");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityTypeProductSelectors_SecurityTypeProductSelector_ProductID",
                table: "SecurityTypeProductSelectors",
                column: "SecurityTypeProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SelfEmployedClassificationProductSelectors_SelfEmployedClassificationProductSelector_ProductID",
                table: "SelfEmployedClassificationProductSelectors",
                column: "SelfEmployedClassificationProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SelfEmployedClassificationProductSelectors_SelfEmployedClassificationProductSelector_SelfEmployedClassificationID",
                table: "SelfEmployedClassificationProductSelectors",
                column: "SelfEmployedClassificationProductSelector_SelfEmployedClassificationID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypeProductSelectors_ServiceTypeProductSelector_CouncilZoningTypeID",
                table: "ServiceTypeProductSelectors",
                column: "ServiceTypeProductSelector_CouncilZoningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypeProductSelectors_ServiceTypeProductSelector_GeneralLookUpID",
                table: "ServiceTypeProductSelectors",
                column: "ServiceTypeProductSelector_GeneralLookUpID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypeProductSelectors_ServiceTypeProductSelector_ProductID",
                table: "ServiceTypeProductSelectors",
                column: "ServiceTypeProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Suburbs_SuburbStateID",
                table: "Suburbs",
                column: "SuburbStateID");

            migrationBuilder.CreateIndex(
                name: "IX_TitleTypeProductSelectors_TitleTypeProductSelector_CouncilZoningTypeID",
                table: "TitleTypeProductSelectors",
                column: "TitleTypeProductSelector_CouncilZoningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_TitleTypeProductSelectors_TitleTypeProductSelector_GeneralLookUpID",
                table: "TitleTypeProductSelectors",
                column: "TitleTypeProductSelector_GeneralLookUpID");

            migrationBuilder.CreateIndex(
                name: "IX_TitleTypeProductSelectors_TitleTypeProductSelector_ProductID",
                table: "TitleTypeProductSelectors",
                column: "TitleTypeProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_UnitsApartmentProductSelectors_UnitsApartmentProductSelector_ProductID",
                table: "UnitsApartmentProductSelectors",
                column: "UnitsApartmentProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_UsageTypeProductSelectors_UsageTypeProductSelector_CouncilZoningTypeID",
                table: "UsageTypeProductSelectors",
                column: "UsageTypeProductSelector_CouncilZoningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_UsageTypeProductSelectors_UsageTypeProductSelector_GeneralLookUpID",
                table: "UsageTypeProductSelectors",
                column: "UsageTypeProductSelector_GeneralLookUpID");

            migrationBuilder.CreateIndex(
                name: "IX_UsageTypeProductSelectors_UsageTypeProductSelector_ProductID",
                table: "UsageTypeProductSelectors",
                column: "UsageTypeProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ZoningTypeProductSelectors_ZoningTypeProductSelector_CouncilZoningCategoryID",
                table: "ZoningTypeProductSelectors",
                column: "ZoningTypeProductSelector_CouncilZoningCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ZoningTypeProductSelectors_ZoningTypeProductSelector_CouncilZoningTypeID",
                table: "ZoningTypeProductSelectors",
                column: "ZoningTypeProductSelector_CouncilZoningTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ZoningTypeProductSelectors_ZoningTypeProductSelector_ProductID",
                table: "ZoningTypeProductSelectors",
                column: "ZoningTypeProductSelector_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ZoningTypeProductSelectors_ZoningTypeProductSelector_StateID",
                table: "ZoningTypeProductSelectors",
                column: "ZoningTypeProductSelector_StateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalFeeDocTypeVariations");

            migrationBuilder.DropTable(
                name: "AdditionalFees");

            migrationBuilder.DropTable(
                name: "AgeCreditReportProductSelectors");

            migrationBuilder.DropTable(
                name: "ApplicationObjectiveProductSelectors");

            migrationBuilder.DropTable(
                name: "BorrowingEntityProductSelectors");

            migrationBuilder.DropTable(
                name: "ButtonTypeProductSelectors");

            migrationBuilder.DropTable(
                name: "CashOutProductSelectors");

            migrationBuilder.DropTable(
                name: "CategoryTypes");

            migrationBuilder.DropTable(
                name: "ConstructionProductSelectors");

            migrationBuilder.DropTable(
                name: "DefaultFees");

            migrationBuilder.DropTable(
                name: "DefaultSettings");

            migrationBuilder.DropTable(
                name: "DocTypeProductSelectors");

            migrationBuilder.DropTable(
                name: "DwellingsProductSelectors");

            migrationBuilder.DropTable(
                name: "EmployerClassificationProductSelectors");

            migrationBuilder.DropTable(
                name: "EmploymentClassificationProductSelectors");

            migrationBuilder.DropTable(
                name: "FacilityTypeProductSelectors");

            migrationBuilder.DropTable(
                name: "GuidedByTypeProductSelectors");

            migrationBuilder.DropTable(
                name: "HeedFullPointTypeProductSelectors");

            migrationBuilder.DropTable(
                name: "LandSizeProductSelectors");

            migrationBuilder.DropTable(
                name: "LoanAmountProductSelectors");

            migrationBuilder.DropTable(
                name: "LvrProductSelectors");

            migrationBuilder.DropTable(
                name: "MaritalStatusProductSelectors");

            migrationBuilder.DropTable(
                name: "NaturalPersonAgeProductSelectors");

            migrationBuilder.DropTable(
                name: "NumeralClassifications");

            migrationBuilder.DropTable(
                name: "OtherIncomeTypeProductSelectors");

            migrationBuilder.DropTable(
                name: "PostcodeClassificationMapper");

            migrationBuilder.DropTable(
                name: "PostcodeProductSelectors");

            migrationBuilder.DropTable(
                name: "PostcodeSuburbMapper");

            migrationBuilder.DropTable(
                name: "PotentialImpactfulConsiderationProductSelectors");

            migrationBuilder.DropTable(
                name: "ProductCatalogues");

            migrationBuilder.DropTable(
                name: "ProductFeeLVRRates");

            migrationBuilder.DropTable(
                name: "PurchaseTypeProductSelectors");

            migrationBuilder.DropTable(
                name: "RepaymentTypeProductSelectors");

            migrationBuilder.DropTable(
                name: "RulesFilters");

            migrationBuilder.DropTable(
                name: "ScenarioBuilders");

            migrationBuilder.DropTable(
                name: "SecurityTypeProductSelectors");

            migrationBuilder.DropTable(
                name: "SelfEmployedClassificationProductSelectors");

            migrationBuilder.DropTable(
                name: "ServiceTypeProductSelectors");

            migrationBuilder.DropTable(
                name: "TitleTypeProductSelectors");

            migrationBuilder.DropTable(
                name: "UnitsApartmentProductSelectors");

            migrationBuilder.DropTable(
                name: "UsageTypeProductSelectors");

            migrationBuilder.DropTable(
                name: "ZoningTypeProductSelectors");

            migrationBuilder.DropTable(
                name: "LandSizes");

            migrationBuilder.DropTable(
                name: "ApplicationObjectiveClassifications");

            migrationBuilder.DropTable(
                name: "BorrowingEntityTypes");

            migrationBuilder.DropTable(
                name: "BusinessFinanceTypes");

            migrationBuilder.DropTable(
                name: "CashOutTypes");

            migrationBuilder.DropTable(
                name: "BuilderTypes");

            migrationBuilder.DropTable(
                name: "ConstructionTypes");

            migrationBuilder.DropTable(
                name: "RenovationTypes");

            migrationBuilder.DropTable(
                name: "LoanToValueRatios");

            migrationBuilder.DropTable(
                name: "EmploymentClassifications");

            migrationBuilder.DropTable(
                name: "LandSizeClassifications");

            migrationBuilder.DropTable(
                name: "OtherIncomeTypes");

            migrationBuilder.DropTable(
                name: "PostcodeSpecificationMapper");

            migrationBuilder.DropTable(
                name: "Postcodes");

            migrationBuilder.DropTable(
                name: "Suburbs");

            migrationBuilder.DropTable(
                name: "DocTypes");

            migrationBuilder.DropTable(
                name: "RelocationServicings");

            migrationBuilder.DropTable(
                name: "VacantLandCategories");

            migrationBuilder.DropTable(
                name: "SelfEmployedClassifications");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "GeneralLookUps");

            migrationBuilder.DropTable(
                name: "CouncilZoningCategories");

            migrationBuilder.DropTable(
                name: "PostcodeClassifications");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
