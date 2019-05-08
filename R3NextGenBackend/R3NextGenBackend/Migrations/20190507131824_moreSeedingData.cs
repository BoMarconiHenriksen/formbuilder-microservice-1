using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace R3NextGenBackend.Migrations
{
    public partial class moreSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Component",
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

            migrationBuilder.InsertData(
                table: "Form",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2L, "Affaldssortering" },
                    { 3L, "Biluheld" },
                    { 4L, "Overfald" },
                    { 5L, "Underet Borgmesterkontoret" },
                    { 6L, "Kemikaliebrand" },
                    { 7L, "Tilkald helikopter" }
                });

            migrationBuilder.InsertData(
                table: "CompletedForm",
                columns: new[] { "Id", "CompletedDate", "FormId", "UserId" },
                values: new object[,]
                {
                    { 2L, new DateTime(2019, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2L, 2L },
                    { 3L, new DateTime(2019, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 3L, 3L },
                    { 4L, new DateTime(2019, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 4L, 1L },
                    { 5L, new DateTime(2019, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 5L, 2L },
                    { 6L, new DateTime(2019, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 6L, 1L },
                    { 7L, new DateTime(2019, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 7L, 1L }
                });

            migrationBuilder.InsertData(
                table: "FormField",
                columns: new[] { "Id", "Column", "FormId", "Headline", "Height", "Row", "Static", "Width" },
                values: new object[,]
                {
                    { 2L, 2, 2L, "Er der en affaldsspand", 3, 3, false, 2 },
                    { 3L, 3, 3L, "Antal kvæstede", 4, 3, false, 3 },
                    { 4L, 3, 4L, "Overfaldsvåben", 5, 3, false, 3 },
                    { 5L, 3, 5L, "Skal komunaldirektøren underrettes", 2, 3, false, 5 },
                    { 6L, 3, 6L, "Hvilken type kemikalie er i brand?", 5, 3, false, 5 },
                    { 7L, 3, 7L, "Hvor skal helikopteren lande?", 2, 3, false, 3 }
                });

            migrationBuilder.InsertData(
                table: "Component",
                columns: new[] { "Id", "ComponentName", "FormFieldId" },
                values: new object[,]
                {
                    { 2L, "appInputFieldComponent", 2L },
                    { 3L, "appInputFieldComponent", 3L },
                    { 4L, "appInputFieldComponent", 4L },
                    { 5L, "appInputFieldComponent", 5L },
                    { 6L, "appInputFieldComponent", 6L },
                    { 7L, "appInputFieldComponent", 7L }
                });

            migrationBuilder.InsertData(
                table: "FormFieldValue",
                columns: new[] { "Id", "CompletedFormId", "FormFieldId", "FormFieldId1", "Value" },
                values: new object[,]
                {
                    { 2L, 2L, 2L, null, "Dette er valuen" },
                    { 3L, 3L, 3L, null, "Dette er valuen" },
                    { 4L, 4L, 4L, null, "Dette er valuen" },
                    { 5L, 5L, 5L, null, "Dette er valuen" },
                    { 6L, 6L, 6L, null, "Dette er valuen" },
                    { 7L, 7L, 7L, null, "Dette er valuen" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Component",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Component",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Component",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Component",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Component",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Component",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "FormFieldValue",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "FormFieldValue",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "FormFieldValue",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "FormFieldValue",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "FormFieldValue",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "FormFieldValue",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "CompletedForm",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "CompletedForm",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "CompletedForm",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "CompletedForm",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "CompletedForm",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "CompletedForm",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "FormField",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "FormField",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "FormField",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "FormField",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "FormField",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "FormField",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Form",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Form",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Form",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Form",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Form",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Form",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.InsertData(
                table: "Form",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "Brand" });

            migrationBuilder.InsertData(
                table: "CompletedForm",
                columns: new[] { "Id", "CompletedDate", "FormId", "UserId" },
                values: new object[] { 1L, new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Local), 1L, 1L });

            migrationBuilder.InsertData(
                table: "FormField",
                columns: new[] { "Id", "Column", "FormId", "Headline", "Height", "Row", "Static", "Width" },
                values: new object[] { 1L, 3, 1L, "Indtast Dit Navn", 3, 3, false, 3 });

            migrationBuilder.InsertData(
                table: "Component",
                columns: new[] { "Id", "ComponentName", "FormFieldId" },
                values: new object[] { 1L, "appInputFieldComponent", 1L });

            migrationBuilder.InsertData(
                table: "FormFieldValue",
                columns: new[] { "Id", "CompletedFormId", "FormFieldId", "FormFieldId1", "Value" },
                values: new object[] { 1L, 1L, 1L, null, "Dette er valuen" });
        }
    }
}
