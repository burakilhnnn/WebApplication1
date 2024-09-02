using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResetPassword_Users_UserId",
                table: "ResetPassword");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResetPassword",
                table: "ResetPassword");

            migrationBuilder.RenameTable(
                name: "ResetPassword",
                newName: "ResetPasswords");

            migrationBuilder.RenameIndex(
                name: "IX_ResetPassword_UserId",
                table: "ResetPasswords",
                newName: "IX_ResetPasswords_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "ResetCode",
                table: "ResetPasswords",
                type: "character varying(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "ResetPasswords",
                type: "timestamp with time zone",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "Ip",
                table: "ResetPasswords",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiryDate",
                table: "ResetPasswords",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ResetPasswords",
                type: "timestamp with time zone",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResetPasswords",
                table: "ResetPasswords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResetPasswords_Users_UserId",
                table: "ResetPasswords",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResetPasswords_Users_UserId",
                table: "ResetPasswords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResetPasswords",
                table: "ResetPasswords");

            migrationBuilder.RenameTable(
                name: "ResetPasswords",
                newName: "ResetPassword");

            migrationBuilder.RenameIndex(
                name: "IX_ResetPasswords_UserId",
                table: "ResetPassword",
                newName: "IX_ResetPassword_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "ResetCode",
                table: "ResetPassword",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "ResetPassword",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<int>(
                name: "Ip",
                table: "ResetPassword",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiryDate",
                table: "ResetPassword",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ResetPassword",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResetPassword",
                table: "ResetPassword",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResetPassword_Users_UserId",
                table: "ResetPassword",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
