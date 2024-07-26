using BlogApp.Domain.Entities;
using BlogApp.Domain.Repositories;
using BlogApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogApp.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogAppDbContext _context;

        public CommentRepository(BlogAppDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<IEnumerable<Comment>> FindAsync(Expression<Func<Comment, bool>> predicate)
        {
            return await _context.Comments.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetByBlogPostIdAsync(int blogPostId)
        {
            return await _context.Comments.Where(c => c.BlogPostId == blogPostId).ToListAsync();
        }

        public async Task AddAsync(Comment entity)
        {
            await _context.Comments.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(Comment entity)
        {
            _context.Comments.Remove(entity);
            _context.SaveChanges();
        }
    }
}
