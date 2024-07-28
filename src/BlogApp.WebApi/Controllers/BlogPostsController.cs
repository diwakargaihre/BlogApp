using AutoMapper;
using BlogApp.Application.DTO;
using BlogApp.Application.Interfaces;
using BlogApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostController(IBlogPostService blogPostService, IMapper mapper)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPostDto>> GetBlogPost(int id)
        {
            var blogPost = await _blogPostService.GetBlogPostByIdAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }
            return Ok(blogPost);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPostDto>>> GetBlogPosts()
        {
            var blogPosts = await _blogPostService.GetAllBlogPostsAsync();
            return Ok(blogPosts);
        }

        [HttpPost]
        public async Task<ActionResult> PostBlogPost(BlogPostDto blogPostDto)
        {
            await _blogPostService.AddBlogPostAsync(blogPostDto);
            return Ok(new { message = "Blog post created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutBlogPost(int id, BlogPostDto blogPostDto)
        {
            if (id != blogPostDto.Id)
            {
                return BadRequest();
            }
            await _blogPostService.UpdateBlogPostAsync(blogPostDto);
            return Ok(new { message = "Blog post updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBlogPost(int id)
        {
            await _blogPostService.DeleteBlogPostAsync(id);
            return Ok(new { message = "Blog post deleted successfully" });
        }
    }
}
