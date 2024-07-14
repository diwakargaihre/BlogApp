using BlogApp.Domain.Entities;

namespace BlogApp.Domain.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetByBlogPostIdAsync(int blogPostId);
    }
}
