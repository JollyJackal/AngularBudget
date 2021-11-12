using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularBudget.Migrations
{
    public partial class AddBasicTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Frequency",
                columns: table => new
                {
                    FrequencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrequencyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequency", x => x.FrequencyId);
                });

            migrationBuilder.CreateTable(
                name: "Regularity",
                columns: table => new
                {
                    RegularityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegularityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regularity", x => x.RegularityId);
                });

            migrationBuilder.CreateTable(
                name: "UserBillCompany",
                columns: table => new
                {
                    UserBillCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBillCompany", x => x.UserBillCompanyId);
                    table.ForeignKey(
                        name: "FK_UserBillCompany_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserIncomeCompany",
                columns: table => new
                {
                    UserIncomeCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIncomeCompany", x => x.UserIncomeCompanyId);
                    table.ForeignKey(
                        name: "FK_UserIncomeCompany_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserBudget",
                columns: table => new
                {
                    UserBudgetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FrequencyId = table.Column<int>(type: "int", nullable: false),
                    FrequencyAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBudget", x => x.UserBudgetId);
                    table.ForeignKey(
                        name: "FK_UserBudget_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBudget_Frequency_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequency",
                        principalColumn: "FrequencyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserBill",
                columns: table => new
                {
                    UserBillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEstimate = table.Column<bool>(type: "bit", nullable: false),
                    BillAmount = table.Column<int>(type: "int", nullable: false),
                    BillDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegularityId = table.Column<int>(type: "int", nullable: false),
                    FrequencyId = table.Column<int>(type: "int", nullable: false),
                    FrequencyAmount = table.Column<int>(type: "int", nullable: false),
                    UserBillCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBill", x => x.UserBillId);
                    table.ForeignKey(
                        name: "FK_UserBill_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBill_Frequency_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequency",
                        principalColumn: "FrequencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBill_Regularity_RegularityId",
                        column: x => x.RegularityId,
                        principalTable: "Regularity",
                        principalColumn: "RegularityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBill_UserBillCompany_UserBillCompanyId",
                        column: x => x.UserBillCompanyId,
                        principalTable: "UserBillCompany",
                        principalColumn: "UserBillCompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserIncome",
                columns: table => new
                {
                    UserIncomeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncomeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEstimate = table.Column<bool>(type: "bit", nullable: false),
                    IncomeAmount = table.Column<int>(type: "int", nullable: false),
                    IncomeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegularityId = table.Column<int>(type: "int", nullable: false),
                    FrequencyId = table.Column<int>(type: "int", nullable: false),
                    FrequencyAmount = table.Column<int>(type: "int", nullable: false),
                    UserIncomeCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIncome", x => x.UserIncomeId);
                    table.ForeignKey(
                        name: "FK_UserIncome_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserIncome_Frequency_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequency",
                        principalColumn: "FrequencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserIncome_Regularity_RegularityId",
                        column: x => x.RegularityId,
                        principalTable: "Regularity",
                        principalColumn: "RegularityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserIncome_UserIncomeCompany_UserIncomeCompanyId",
                        column: x => x.UserIncomeCompanyId,
                        principalTable: "UserIncomeCompany",
                        principalColumn: "UserIncomeCompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Frequency",
                columns: new[] { "FrequencyId", "FrequencyName" },
                values: new object[,]
                {
                    { 1, "Days" },
                    { 2, "Weeks" },
                    { 3, "Months" }
                });

            migrationBuilder.InsertData(
                table: "Regularity",
                columns: new[] { "RegularityId", "RegularityName" },
                values: new object[,]
                {
                    { 1, "One Time" },
                    { 2, "Recurring" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBill_ApplicationUserId",
                table: "UserBill",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBill_FrequencyId",
                table: "UserBill",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBill_RegularityId",
                table: "UserBill",
                column: "RegularityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBill_UserBillCompanyId",
                table: "UserBill",
                column: "UserBillCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBillCompany_ApplicationUserId",
                table: "UserBillCompany",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBudget_ApplicationUserId",
                table: "UserBudget",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBudget_FrequencyId",
                table: "UserBudget",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIncome_ApplicationUserId",
                table: "UserIncome",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIncome_FrequencyId",
                table: "UserIncome",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIncome_RegularityId",
                table: "UserIncome",
                column: "RegularityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIncome_UserIncomeCompanyId",
                table: "UserIncome",
                column: "UserIncomeCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIncomeCompany_ApplicationUserId",
                table: "UserIncomeCompany",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBill");

            migrationBuilder.DropTable(
                name: "UserBudget");

            migrationBuilder.DropTable(
                name: "UserIncome");

            migrationBuilder.DropTable(
                name: "UserBillCompany");

            migrationBuilder.DropTable(
                name: "Frequency");

            migrationBuilder.DropTable(
                name: "Regularity");

            migrationBuilder.DropTable(
                name: "UserIncomeCompany");
        }
    }
}
