using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb4_MVC.Migrations
{
    public partial class fixedproblem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookLoans_Books_FkBookId",
                table: "BookLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_BookLoans_Customers_FkCustomerId",
                table: "BookLoans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookLoans",
                table: "BookLoans");

            migrationBuilder.RenameTable(
                name: "BookLoans",
                newName: "Loans");

            migrationBuilder.RenameIndex(
                name: "IX_BookLoans_FkCustomerId",
                table: "Loans",
                newName: "IX_Loans_FkCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_BookLoans_FkBookId",
                table: "Loans",
                newName: "IX_Loans_FkBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loans",
                table: "Loans",
                column: "LoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Books_FkBookId",
                table: "Loans",
                column: "FkBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Customers_FkCustomerId",
                table: "Loans",
                column: "FkCustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Books_FkBookId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Customers_FkCustomerId",
                table: "Loans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loans",
                table: "Loans");

            migrationBuilder.RenameTable(
                name: "Loans",
                newName: "BookLoans");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_FkCustomerId",
                table: "BookLoans",
                newName: "IX_BookLoans_FkCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_FkBookId",
                table: "BookLoans",
                newName: "IX_BookLoans_FkBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookLoans",
                table: "BookLoans",
                column: "LoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookLoans_Books_FkBookId",
                table: "BookLoans",
                column: "FkBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookLoans_Customers_FkCustomerId",
                table: "BookLoans",
                column: "FkCustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
