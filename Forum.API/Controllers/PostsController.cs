using Forum.API.Contracts;
using Forum.API.DTOs;
using Forum.Application.Interfaces.Repositories;
using Forum.Application.Interfaces.Services;
using Forum.Application.Models;
using Forum.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;
        private readonly IUsersService _usersService;
        private readonly IPostCategoriesService _postCategoriesService;

        public PostsController(IPostsService postsService, IUsersService usersService, IPostCategoriesService postCategoriesService)
        {
            _postsService = postsService;
            _usersService = usersService;
            _postCategoriesService = postCategoriesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostResponse>>> GetAllPosts()
        {
            IEnumerable<Post> posts = await _postsService.GetAllPosts();
            IEnumerable<PostResponse> response = posts.Select(p => new PostResponse(p.Id, p.Title, p.Description, p.CreatedAt));
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostResponse>> GetPostById(Guid id)
        {
            try
            {
                Post post = await _postsService.GetPostById(id);
                PostResponse response = new PostResponse(post.Id, post.Title, post.Description, post.CreatedAt);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PostResponse>> CreatePost(CreatePostDto createPostDto)
        {
            try
            {
                IEnumerable<User> users = await _usersService.GetAllUsers();
                IEnumerable<PostCategory> postCategories = await _postCategoriesService.GetAllPostCategories();
                Post postModel = Post.CreateFromDto(createPostDto.Title, createPostDto.Description, users.First().Id, postCategories.First().Id);
                Post post = await _postsService.CreatePost(postModel);
                PostResponse response = new PostResponse(post.Id, post.Title, post.Description, post.CreatedAt);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PostCategoryResponse>> UpdatePostCategory(Guid id, string title)
        {
            try
            {
                PostCategory postCategoryModel = await _postCategoriesService.GetPostCategoryById(id);
                postCategoryModel.Title = title ?? postCategoryModel.Title;

                PostCategory postCategoryUpdate = await _postCategoriesService.CreatePostCategory(postCategoryModel);
                PostCategoryResponse response = new PostCategoryResponse(postCategoryUpdate.Id, postCategoryUpdate.Title);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePostCategory(Guid id)
        {
            await _postCategoriesService.DeletePostCategory(id);
            return Ok();
        }
    }
}
