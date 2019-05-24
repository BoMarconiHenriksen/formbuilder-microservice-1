using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace R3NextGenBackend
{
    public class Program
    {
        public static async Task Main(string[] args) // deleted void
        {
            // CreateWebHostBuilder(args).Build().Run();

            IWebHost webHost = CreateWebHostBuilder(args).Build();

            // Create a new scope
            using (var scope = webHost.Services.CreateScope())
            {
                // Get the DbContext instance
                var myDbContext = scope.ServiceProvider.GetRequiredService<RepositoryContext>();

                //Do the migration asynchronously
                await myDbContext.Database.MigrateAsync();
            }

            // Run the WebHost, and start accepting requests
            // There's an async overload, so we may as well use it
            await webHost.RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
