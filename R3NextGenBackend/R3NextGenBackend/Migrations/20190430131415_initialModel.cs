using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace R3NextGenBackend.Migrations
{
    public partial class initialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "FormFieldValue",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "CompletedForm",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "FormField",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Form",
                keyColumn: "Id",
                keyValue: 1L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Form",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "Brand" });

            migrationBuilder.InsertData(
                table: "CompletedForm",
                columns: new[] { "Id", "CompletedDate", "FormId", "UserId" },
                values: new object[] { 1L, new DateTime(2019, 4, 30, 0, 0, 0, 0, DateTimeKind.Local), 1L, 1L });

            migrationBuilder.InsertData(
                table: "FormField",
                columns: new[] { "Id", "Column", "FormId", "Headline", "Height", "Row", "Static", "Width" },
                values: new object[] { 1L, 3, 1L, "Indtast Dit Navn", 3, 3, false, 3 });

            migrationBuilder.InsertData(
                table: "Field",
                columns: new[] { "Id", "Component", "FormFieldId" },
                values: new object[] { 1L, "appInputFieldComponent", 1L });

            migrationBuilder.InsertData(
                table: "FormFieldValue",
                columns: new[] { "Id", "CompletedFormId", "FormFieldId", "FormFieldId1", "Value" },
                values: new object[] { 1L, 1L, 1L, null, "Dette er valuen" });
        }
    }
}
