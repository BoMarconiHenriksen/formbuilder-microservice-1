﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using R3NextGenBackend;

namespace R3NextGenBackend.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackendNextGen.Models.CompletedForm", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CompletedDate");

                    b.Property<long>("FormId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("CompletedForm");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CompletedDate = new DateTime(2019, 5, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            FormId = 1L,
                            UserId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            CompletedDate = new DateTime(2019, 5, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            FormId = 2L,
                            UserId = 2L
                        },
                        new
                        {
                            Id = 3L,
                            CompletedDate = new DateTime(2019, 5, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            FormId = 3L,
                            UserId = 3L
                        },
                        new
                        {
                            Id = 4L,
                            CompletedDate = new DateTime(2019, 5, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            FormId = 4L,
                            UserId = 1L
                        },
                        new
                        {
                            Id = 5L,
                            CompletedDate = new DateTime(2019, 5, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            FormId = 5L,
                            UserId = 2L
                        },
                        new
                        {
                            Id = 6L,
                            CompletedDate = new DateTime(2019, 5, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            FormId = 6L,
                            UserId = 1L
                        },
                        new
                        {
                            Id = 7L,
                            CompletedDate = new DateTime(2019, 5, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            FormId = 7L,
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("BackendNextGen.Models.Component", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComponentName")
                        .HasMaxLength(25);

                    b.Property<long>("FormFieldId");

                    b.HasKey("Id");

                    b.HasIndex("FormFieldId")
                        .IsUnique();

                    b.ToTable("Component");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ComponentName = "appInputFieldComponent",
                            FormFieldId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            ComponentName = "appInputFieldComponent",
                            FormFieldId = 2L
                        },
                        new
                        {
                            Id = 3L,
                            ComponentName = "appInputFieldComponent",
                            FormFieldId = 3L
                        },
                        new
                        {
                            Id = 4L,
                            ComponentName = "appInputFieldComponent",
                            FormFieldId = 4L
                        },
                        new
                        {
                            Id = 5L,
                            ComponentName = "appInputFieldComponent",
                            FormFieldId = 5L
                        },
                        new
                        {
                            Id = 6L,
                            ComponentName = "appInputFieldComponent",
                            FormFieldId = 6L
                        },
                        new
                        {
                            Id = 7L,
                            ComponentName = "appInputFieldComponent",
                            FormFieldId = 7L
                        });
                });

            modelBuilder.Entity("BackendNextGen.Models.Form", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Form");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Brand"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Affaldssortering"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Biluheld"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Overfald"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Underet Borgmesterkontoret"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Kemikaliebrand"
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Tilkald helikopter"
                        });
                });

            modelBuilder.Entity("BackendNextGen.Models.FormField", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Column");

                    b.Property<long>("FormId");

                    b.Property<string>("Headline");

                    b.Property<int>("Height");

                    b.Property<int>("Row");

                    b.Property<bool>("Static");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("FormField");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Column = 3,
                            FormId = 1L,
                            Headline = "Indtast Dit Navn",
                            Height = 3,
                            Row = 3,
                            Static = false,
                            Width = 3
                        },
                        new
                        {
                            Id = 2L,
                            Column = 2,
                            FormId = 2L,
                            Headline = "Er der en affaldsspand",
                            Height = 3,
                            Row = 3,
                            Static = false,
                            Width = 2
                        },
                        new
                        {
                            Id = 3L,
                            Column = 3,
                            FormId = 3L,
                            Headline = "Antal kvæstede",
                            Height = 4,
                            Row = 3,
                            Static = false,
                            Width = 3
                        },
                        new
                        {
                            Id = 4L,
                            Column = 3,
                            FormId = 4L,
                            Headline = "Overfaldsvåben",
                            Height = 5,
                            Row = 3,
                            Static = false,
                            Width = 3
                        },
                        new
                        {
                            Id = 5L,
                            Column = 3,
                            FormId = 5L,
                            Headline = "Skal komunaldirektøren underrettes",
                            Height = 2,
                            Row = 3,
                            Static = false,
                            Width = 5
                        },
                        new
                        {
                            Id = 6L,
                            Column = 3,
                            FormId = 6L,
                            Headline = "Hvilken type kemikalie er i brand?",
                            Height = 5,
                            Row = 3,
                            Static = false,
                            Width = 5
                        },
                        new
                        {
                            Id = 7L,
                            Column = 3,
                            FormId = 7L,
                            Headline = "Hvor skal helikopteren lande?",
                            Height = 2,
                            Row = 3,
                            Static = false,
                            Width = 3
                        });
                });

            modelBuilder.Entity("BackendNextGen.Models.FormFieldValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CompletedFormId");

                    b.Property<long>("FormFieldId");

                    b.Property<string>("Value")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("CompletedFormId");

                    b.HasIndex("FormFieldId");

                    b.ToTable("FormFieldValue");
                });

            modelBuilder.Entity("BackendNextGen.Models.CompletedForm", b =>
                {
                    b.HasOne("BackendNextGen.Models.Form", "Form")
                        .WithMany("CompletedForms")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BackendNextGen.Models.Component", b =>
                {
                    b.HasOne("BackendNextGen.Models.FormField", "FormField")
                        .WithOne("Component")
                        .HasForeignKey("BackendNextGen.Models.Component", "FormFieldId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BackendNextGen.Models.FormField", b =>
                {
                    b.HasOne("BackendNextGen.Models.Form", "Form")
                        .WithMany("FormFields")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BackendNextGen.Models.FormFieldValue", b =>
                {
                    b.HasOne("BackendNextGen.Models.CompletedForm", "CompletedForm")
                        .WithMany()
                        .HasForeignKey("CompletedFormId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BackendNextGen.Models.FormField", "FormField")
                        .WithMany()
                        .HasForeignKey("FormFieldId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
