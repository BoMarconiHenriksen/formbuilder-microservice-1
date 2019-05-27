using BackendNextGen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace R3NextGenBackend.Models
{
    public class DbInitializer
    {
        public static void Initialize(RepositoryContext context)
        {
            // EnsureCreated.
            // ensures that the database for the context exists. 
            // If it exists, no action is taken. 
            // If it does not exist then the database and all its schema are created and 
            // also it ensures it is compatible with the model for this context.
            context.Database.EnsureCreated();

            // Look for any forms.
            if (context.Form.Any())
            {
                return;   // DB has been seeded
            }


            // https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-2.2
            // You can write seed data here if needed.

        }

    }
}
