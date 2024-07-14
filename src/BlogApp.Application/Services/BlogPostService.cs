using BlogApp.Application.DTO;
using BlogApp.Application.Interfaces;
using BlogApp.Domain.Entities;
using BlogApp.Domain.Repositories;

namespace BlogApp.Application.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<BlogPostDto> GetBlogPostByIdAsync(int id)
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(id);
            return new BlogPostDto
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Content = blogPost.Content,
                PublishedDate = blogPost.PublishedDate,
                UserId = blogPost.UserId
            };
        }

        public async Task<IEnumerable<BlogPostDto>> GetAllBlogPostsAsync()
        {
            var blogPosts = await _blogPostRepository.GetAllAsync();
            return blogPosts.Select(blogPost => new BlogPostDto
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Content = blogPost.Content,
                PublishedDate = blogPost.PublishedDate,
                UserId = blogPost.UserId
            });
        }

        public async Task AddBlogPostAsync(BlogPostDto blogPostDto)
        {
            var blogPost = new BlogPost
            {
                Title = blogPostDto.Title,
                Content = blogPostDto.Content,
                PublishedDate = blogPostDto.PublishedDate,
                UserId = blogPostDto.UserId
            };
            await _blogPostRepository.AddAsync(blogPost);
        }

        public async Task UpdateBlogPostAsync(BlogPostDto blogPostDto)
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(blogPostDto.Id);
            if (blogPost != null)
            {
                blogPost.Title = blogPostDto.Title;
                blogPost.Content = blogPostDto.Content;
                blogPost.PublishedDate = blogPostDto.PublishedDate;
                _blogPostRepository.Update(blogPost);
            }
        }

        public async Task DeleteBlogPostAsync(int id)
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(id);
            if (blogPost != null)
            {
                _blogPostRepository.Remove(blogPost);
            }
        }
    }
}
