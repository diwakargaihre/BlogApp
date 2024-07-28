using AutoMapper;
using BlogApp.Application.DTO;
using BlogApp.Application.Interfaces;
using BlogApp.Domain.Entities;
using BlogApp.Domain.Repositories;

namespace BlogApp.Application.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;

        public BlogPostService(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
        }

        public async Task<BlogPostDto> GetBlogPostByIdAsync(int id)
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(id);
            return _mapper.Map<BlogPostDto>(blogPost);
        }

        public async Task<IEnumerable<BlogPostDto>> GetAllBlogPostsAsync()
        {
            var blogPosts = await _blogPostRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BlogPostDto>>(blogPosts);
        }

        public async Task AddBlogPostAsync(BlogPostDto blogPostDto)
        {
            var blogPost = _mapper.Map<BlogPost>(blogPostDto);
            await _blogPostRepository.AddAsync(blogPost);
        }

        public async Task UpdateBlogPostAsync(BlogPostDto blogPostDto)
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(blogPostDto.Id);
            if (blogPost != null)
            {
                _mapper.Map(blogPostDto, blogPost);
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
