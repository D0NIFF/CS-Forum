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
    public class PostCategoriesController : ControllerBase
    {
        private readonly IPostCategoriesService _postCategoriesService;

        public PostCategoriesController(IPostCategoriesService postCategoriesService)
        {
            _postCategoriesService = postCategoriesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostCategoryResponse>>> GetAllPostCategories()
        {
            IEnumerable<PostCategory> postCategories = await _postCategoriesService.GetAllPostCategories();
            IEnumerable<PostCategoryResponse> response = postCategories.Select(c => new PostCategoryResponse(c.Id, c.Title));
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostCategoryResponse>> GetPostCategoryById(Guid id)
        {
            try
            {
                PostCategory postCategory = await _postCategoriesService.GetPostCategoryById(id);
                PostCategoryResponse response = new PostCategoryResponse(postCategory.Id, postCategory.Title);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PostCategoryResponse>> CreatePostCategory(string title)
        {
            try
            {
                PostCategory postCategoryModel = PostCategory.CreateFromDto(title);
                PostCategory postCategory = await _postCategoriesService.CreatePostCategory(postCategoryModel);
                PostCategoryResponse response = new PostCategoryResponse(postCategory.Id, postCategory.Title);
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
