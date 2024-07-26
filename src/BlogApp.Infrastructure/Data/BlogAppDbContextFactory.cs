using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BlogApp.Infrastructure.Data
{
    public class BlogAppDbContextFactory : IDesignTimeDbContextFactory<BlogAppDbContext>
    {
        public BlogAppDbContext CreateDbContext(string[] args)
        {
            // Build configuration
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Create DbContextOptionsBuilder
            var optionsBuilder = new DbContextOptionsBuilder<BlogAppDbContext>();

            // Configure the DbContext with the connection string
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new BlogAppDbContext(optionsBuilder.Options);
        }
    }
}
