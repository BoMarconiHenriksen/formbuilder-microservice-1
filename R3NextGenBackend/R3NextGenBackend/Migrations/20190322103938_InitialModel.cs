using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace R3NextGenBackend.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompletedForm",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    CompletedDate = table.Column<DateTime>(nullable: false),
                    FormId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedForm_Form_FormId",
                        column: x => x.FormId,
                        principalTable: "Form",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormField",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Column = table.Column<int>(nullable: false),
                    Row = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Headline = table.Column<string>(nullable: true),
                    Static = table.Column<bool>(nullable: false),
                    FormId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormField_Form_FormId",
                        column: x => x.FormId,
                        principalTable: "Form",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Component = table.Column<string>(maxLength: 25, nullable: true),
                    FormFieldId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Field_FormField_FormFieldId",
                        column: x => x.FormFieldId,
                        principalTable: "FormField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormFieldValue",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(maxLength: 25, nullable: true),
                    FormFieldId = table.Column<long>(nullable: false),
                    CompletedFormId = table.Column<long>(nullable: false),
                    FormFieldId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFieldValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormFieldValue_CompletedForm_CompletedFormId",
                        column: x => x.CompletedFormId,
                        principalTable: "CompletedForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormFieldValue_FormField_FormFieldId",
                        column: x => x.FormFieldId,
                        principalTable: "FormField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormFieldValue_FormField_FormFieldId1",
                        column: x => x.FormFieldId1,
                        principalTable: "FormField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Form",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "Prøve Formular" });

            migrationBuilder.InsertData(
                table: "CompletedForm",
                columns: new[] { "Id", "CompletedDate", "FormId", "UserId" },
                values: new object[] { 1L, new DateTime(2019, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), 1L, 1L });

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

            migrationBuilder.CreateIndex(
                name: "IX_CompletedForm_FormId",
                table: "CompletedForm",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Field_FormFieldId",
                table: "Field",
                column: "FormFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_FormField_FormId",
                table: "FormField",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_FormFieldValue_CompletedFormId",
                table: "FormFieldValue",
                column: "CompletedFormId");

            migrationBuilder.CreateIndex(
                name: "IX_FormFieldValue_FormFieldId",
                table: "FormFieldValue",
                column: "FormFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_FormFieldValue_FormFieldId1",
                table: "FormFieldValue",
                column: "FormFieldId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropTable(
                name: "FormFieldValue");

            migrationBuilder.DropTable(
                name: "CompletedForm");

            migrationBuilder.DropTable(
                name: "FormField");

            migrationBuilder.DropTable(
                name: "Form");
        }
    }
}
