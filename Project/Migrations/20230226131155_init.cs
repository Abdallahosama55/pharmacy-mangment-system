using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exist = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exist = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    CompanyPrice = table.Column<double>(type: "float", nullable: false),
                    Profit = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    exist = table.Column<int>(type: "int", nullable: false),
                    CompID = table.Column<int>(type: "int", nullable: false),
                    ExpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnteredDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Medicine_Company_CompID",
                        column: x => x.CompID,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    exist = table.Column<int>(type: "int", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bill_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MedBills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    TotalProfit = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    exist = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedBills_Bill_BillId",
                        column: x => x.BillId,
                        principalTable: "Bill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MedBills_Medicine_MedId",
                        column: x => x.MedId,
                        principalTable: "Medicine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Address", "Name", "Phone", "exist" },
                values: new object[,]
                {
                    { 1, "Cairo", "Taba medical", "01068100402", 1 },
                    { 2, "Assiut", "Farco", "01007837834", 1 },
                    { 3, "Sohag", "Amanco", "01109283484", 1 },
                    { 4, "Matroh", "Pharma", "01113468920", 1 },
                    { 5, "Cairo", "Sanofi", "01064892436", 1 },
                    { 6, "Cairo", "Gsk", "01173630273", 1 }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "id", "Age", "Email", "exist", "name", "password", "phone", "salary" },
                values: new object[,]
                {
                    { 1, 23, "Mayar@admin", 1, "Mayar", "0123", "0100000", 1000 },
                    { 2, 25, "Mariem@Employee", 1, "Mariem", "1234", "0100000", 2000 },
                    { 3, 24, "hadeer@Employee", 1, "hadeer", "12345", "0100000", 3000 },
                    { 4, 26, "Reem@admin", 1, "Reem", "1679", "01010101", 1000 }
                });

            migrationBuilder.InsertData(
                table: "Medicine",
                columns: new[] { "ID", "CompID", "CompanyPrice", "EnteredDate", "ExpDate", "Name", "ProductionDate", "Profit", "Type", "UnitPrice", "exist", "quantity" },
                values: new object[,]
                {
                    { 1, 6, 40.0, new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2028, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "rapiflam", new DateTime(2020, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0, "Tablet", 50.0, 1, 10 },
                    { 2, 4, 15.0, new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "cataflam", new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.0, "Tablet", 20.0, 1, 10 },
                    { 3, 3, 80.0, new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "buscoban", new DateTime(2021, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.0, "Tablet", 100.0, 1, 10 },
                    { 4, 2, 8.9499999999999993, new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "vegaskiin", new DateTime(2022, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0, "injection", 10.949999999999999, 1, 10 },
                    { 5, 1, 120.0, new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "meranda", new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.0, "injection", 150.0, 1, 10 },
                    { 6, 1, 65.0, new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "teraicten", new DateTime(2022, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, "Syrup", 80.0, 1, 10 },
                    { 7, 2, 36.5, new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "servetam", new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0, "Tablet", 39.5, 1, 10 },
                    { 8, 5, 85.0, new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "banadol", new DateTime(2022, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, "Tablet", 100.0, 1, 10 },
                    { 9, 3, 85.0, new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "depakin", new DateTime(2021, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, "Syrup", 100.0, 1, 10 },
                    { 10, 3, 8.5, new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "profien", new DateTime(2022, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.5, "Syrup", 10.0, 1, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_EmpId",
                table: "Bill",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_MedBills_BillId",
                table: "MedBills",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_MedBills_MedId",
                table: "MedBills",
                column: "MedId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_CompID",
                table: "Medicine",
                column: "CompID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedBills");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
