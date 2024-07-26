using BlogApp.Domain.Entities;
using BlogApp.Domain.Repositories;
using BlogApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogApp.Infrastructure.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogAppDbContext _context;

        public BlogPostRepository(BlogAppDbContext context)
        {
            _context = context;
        }

        public async Task<BlogPost> GetByIdAsync(int id)
        {
            return await _context.BlogPosts.FindAsync(id);
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _context.BlogPosts.ToListAsync();
        }

        public async Task<IEnumerable<BlogPost>> FindAsync(Expression<Func<BlogPost, bool>> predicate)
        {
            return await _context.BlogPosts.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<BlogPost>> GetByUserIdAsync(int userId)
        {
            return await _context.BlogPosts.Where(bp => bp.UserId == userId).ToListAsync();
        }

        public async Task AddAsync(BlogPost entity)
        {
            await _context.BlogPosts.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(BlogPost entity)
        {
            _context.BlogPosts.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(BlogPost entity)
        {
            _context.BlogPosts.Remove(entity);
            _context.SaveChanges();
        }
    }
}
