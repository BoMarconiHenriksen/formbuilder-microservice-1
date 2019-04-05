using BackendNextGen.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace R3NextGenBackend
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<CompletedForm> CompletedForm { get; set; }
        public virtual DbSet<Field> Field { get; set; }
        public virtual DbSet<Form> Form { get; set; }
        public virtual DbSet<FormField> FormField { get; set; }
        public virtual DbSet<FormFieldValue> FormFieldValue { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

           

        }

        // By convention, the Entity Framework enables cascade delete for non-nullable foreign keys and for many-to-many relationships. 
        // This can result in circular cascade delete rules, which will cause an exception when you try to add a migration. 
        // For example, if you didn't define the Department.InstructorID property as nullable, 
        // EF would configure a cascade delete rule to delete the instructor when you delete the department, 
        // which isn't what you want to have happen. 
        // If your business rules required the InstructorID property to be non-nullable, you would have to use the following fluent API statement to disable cascade delete on the relationship:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // sql server
            modelBuilder.Entity<FormFieldValue>()
                .HasOne(f => f.FormField)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            //Seed data.
            modelBuilder.Entity<Form>().HasData(
                new Form()
                { Id = 1, Name = "Prøve Formular" }
                );

            modelBuilder.Entity<CompletedForm>().HasData(
                new CompletedForm()
                { Id = 1, UserId = 1, CompletedDate = DateTime.Now.Date, FormId = 1 }
                );

            modelBuilder.Entity<FormField>().HasData(
                new FormField()
                { Id = 1, Column = 3, Row = 3, Width = 3, Height = 3, Headline = "Indtast Dit Navn", Static = false, FormId = 1 }
                );

            modelBuilder.Entity<FormFieldValue>().HasData(
                new FormFieldValue()
                { Id = 1, Value = "Dette er valuen", FormFieldId = 1, CompletedFormId = 1 }
                );

            modelBuilder.Entity<Field>().HasData(
                new Field()
                { Id = 1, Component = "appInputFieldComponent", FormFieldId = 1 }
                );


        }
    }
}
