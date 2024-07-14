using BlogApp.Domain.Entities;

namespace BlogApp.Domain.Repositories
{
    public interface IBlogPostRepository : IRepository<BlogPost>
    {
        Task<IEnumerable<BlogPost>> GetByUserIdAsync(int userId);
    }
}
