using BlogApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Infrastructure.Data
{
    public class BlogAppDbContext : DbContext
    {
        public BlogAppDbContext(DbContextOptions<BlogAppDbContext> options) : base(options){ }
        
        public DbSet<User> Users {get;set;}
        public DbSet<BlogPost> BlogPosts {get;set;}
        public DbSet<Comment> Comments {get;set;}
        public DbSet<Tag> Tags {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional configuration for entities if needed
        }

    }
}