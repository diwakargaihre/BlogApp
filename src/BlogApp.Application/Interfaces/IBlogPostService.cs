using BlogApp.Application.DTO;

namespace BlogApp.Application.Interfaces
{
    public interface IBlogPostService
    {
        Task<BlogPostDto> GetBlogPostByIdAsync(int id);
        Task<IEnumerable<BlogPostDto>> GetAllBlogPostsAsync();
        Task AddBlogPostAsync(BlogPostDto blogPost);
        Task UpdateBlogPostAsync(BlogPostDto blogPost);
        Task DeleteBlogPostAsync(int id);
    }
}
