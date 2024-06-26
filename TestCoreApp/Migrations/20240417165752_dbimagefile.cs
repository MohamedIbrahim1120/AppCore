﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class dbimagefile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "dbImage",
                table: "categories",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "dbImage",
                value: null);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "dbImage",
                value: null);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "dbImage",
                value: null);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "dbImage",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dbImage",
                table: "categories");
        }
    }
}
