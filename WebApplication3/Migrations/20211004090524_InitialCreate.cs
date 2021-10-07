using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDetailss",
                columns: table => new
                {
                    customerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "678900, 1"),
                    AccountNumber = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuardianType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuardianName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Citizenship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccType = table.Column<string>(type: "string", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitizenStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepositAmmount = table.Column<int>(type: "int", nullable: false),
                    proofType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HolderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HolderAcctNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HolderAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetailss", x => x.customerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDetailss");
        }
    }
}
