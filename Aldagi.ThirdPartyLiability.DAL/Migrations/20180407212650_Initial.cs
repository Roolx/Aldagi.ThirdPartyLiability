using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Aldagi.ThirdPartyLiability.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ManufacturerId = table.Column<int>(nullable: false),
                    ManufacturingYear = table.Column<DateTime>(nullable: false),
                    ModelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "InternalUsers",
                columns: table => new
                {
                    InternalUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalUsers", x => x.InternalUserId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "TPLTerms",
                columns: table => new
                {
                    TPLTermId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bonus = table.Column<decimal>(nullable: false),
                    InternalUserId = table.Column<int>(nullable: false),
                    Limit = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPLTerms", x => x.TPLTermId);
                    table.ForeignKey(
                        name: "FK_TPLTerms_InternalUsers_InternalUserId",
                        column: x => x.InternalUserId,
                        principalTable: "InternalUsers",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TPLDetails",
                columns: table => new
                {
                    TplDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(nullable: false),
                    TPLTermId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPLDetails", x => x.TplDetailsId);
                    table.ForeignKey(
                        name: "FK_TPLDetails_TPLTerms_TPLTermId",
                        column: x => x.TPLTermId,
                        principalTable: "TPLTerms",
                        principalColumn: "TPLTermId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientDetails",
                columns: table => new
                {
                    ClientDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarId = table.Column<int>(nullable: false),
                    CarRegistrationNumber = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    InternalUserId = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    TPLDetailsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDetails", x => x.ClientDetailsId);
                    table.ForeignKey(
                        name: "FK_ClientDetails_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientDetails_TPLDetails_TPLDetailsId",
                        column: x => x.TPLDetailsId,
                        principalTable: "TPLDetails",
                        principalColumn: "TplDetailsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientDetailsId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PersonalId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_ClientDetails_ClientDetailsId",
                        column: x => x.ClientDetailsId,
                        principalTable: "ClientDetails",
                        principalColumn: "ClientDetailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientDetails_CarId",
                table: "ClientDetails",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDetails_TPLDetailsId",
                table: "ClientDetails",
                column: "TPLDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientDetailsId",
                table: "Clients",
                column: "ClientDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_TPLDetails_TPLTermId",
                table: "TPLDetails",
                column: "TPLTermId");

            migrationBuilder.CreateIndex(
                name: "IX_TPLTerms_InternalUserId",
                table: "TPLTerms",
                column: "InternalUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "ClientDetails");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "TPLDetails");

            migrationBuilder.DropTable(
                name: "TPLTerms");

            migrationBuilder.DropTable(
                name: "InternalUsers");
        }
    }
}
