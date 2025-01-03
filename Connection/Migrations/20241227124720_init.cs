using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Connection.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    HolderId = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    IsActice = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Daylitransaction = table.Column<double>(type: "float", nullable: false),
                    SetedLimitationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertingPasswordWrongly = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardNumber);
                    table.ForeignKey(
                        name: "FK_Cards_Users_HolderId",
                        column: x => x.HolderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceCardNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SourceCardId = table.Column<int>(type: "int", nullable: false),
                    DestinationCardNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DestinationCardId = table.Column<int>(type: "int", nullable: false),
                    TransactionDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isSuccessful = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Cards_DestinationCardNumber",
                        column: x => x.DestinationCardNumber,
                        principalTable: "Cards",
                        principalColumn: "CardNumber");
                    table.ForeignKey(
                        name: "FK_Transactions_Cards_SourceCardNumber",
                        column: x => x.SourceCardNumber,
                        principalTable: "Cards",
                        principalColumn: "CardNumber");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "Armin@gmail.com", "Armin", "123", "armin" },
                    { 2, "Ali@gmail.com", "Ali", "123", "ali" },
                    { 3, "Mehdi@gmail.com", "Mehdi", "123", "mehdi" },
                    { 4, "Nazanin@gmail.com", "Nazanin", "123", "nazanin" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardNumber", "Balance", "Daylitransaction", "HolderId", "Id", "InsertingPasswordWrongly", "IsActice", "Password", "SetedLimitationDate" },
                values: new object[,]
                {
                    { "5859831000619801", 2000.0, 0.0, 1, 1, 0, true, "123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "5859831000619802", 2000.0, 0.0, 1, 2, 0, true, "123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "5859831000619803", 2000.0, 0.0, 2, 3, 0, true, "123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "5859831000619804", 2000.0, 0.0, 2, 4, 0, true, "123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "5859831000619805", 2000.0, 0.0, 3, 5, 0, true, "123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_HolderId",
                table: "Cards",
                column: "HolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DestinationCardNumber",
                table: "Transactions",
                column: "DestinationCardNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SourceCardNumber",
                table: "Transactions",
                column: "SourceCardNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
