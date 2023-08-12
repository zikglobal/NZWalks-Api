using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.Api.Migrations
{
    /// <inheritdoc />
    public partial class seedingdataintoDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EgionImageUrl",
                table: "Regions",
                newName: "RegionImageUrl");

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0e9fec06-0a14-407d-8367-48582c3bdbe0"), "Hard" },
                    { new Guid("a43a7986-9ea6-4deb-9d41-31cd4dcc1357"), "Easy" },
                    { new Guid("bd885d12-0d59-4c88-88ef-38cfdc44c830"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("40919be2-f663-41d3-90f4-a2511b364fa2"), "ABJ", "Abuja", null },
                    { new Guid("57c3476f-5148-4822-a1b4-98fbac347e8a"), "MKD", "Makurdi", null },
                    { new Guid("bbf2f790-6c74-4cd2-84bc-62d178335519"), "KD", "Kaduna", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0e9fec06-0a14-407d-8367-48582c3bdbe0"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a43a7986-9ea6-4deb-9d41-31cd4dcc1357"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("bd885d12-0d59-4c88-88ef-38cfdc44c830"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("40919be2-f663-41d3-90f4-a2511b364fa2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("57c3476f-5148-4822-a1b4-98fbac347e8a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("bbf2f790-6c74-4cd2-84bc-62d178335519"));

            migrationBuilder.RenameColumn(
                name: "RegionImageUrl",
                table: "Regions",
                newName: "EgionImageUrl");
        }
    }
}
