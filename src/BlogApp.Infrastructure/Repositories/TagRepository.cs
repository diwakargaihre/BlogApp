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
    public class TagRepository : ITagRepository
    {
        private readonly BlogAppDbContext _context;

        public TagRepository(BlogAppDbContext context)
        {
            _context = context;
        }

        public async Task<Tag> GetByIdAsync(int id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<IEnumerable<Tag>> FindAsync(Expression<Func<Tag, bool>> predicate)
        {
            return await _context.Tags.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(Tag entity)
        {
            await _context.Tags.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(Tag entity)
        {
            _context.Tags.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(Tag entity)
        {
            _context.Tags.Remove(entity);
            _context.SaveChanges();
        }
    }
}
