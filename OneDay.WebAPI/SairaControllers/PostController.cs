using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneDay.Models.Post;
using OneDay.Services.Post;

namespace OneDay.WebAPI.SairaControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostNew post)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            if (await _postService.CreateNewPostAsync(post))
            {
                return Ok("Your post has been uploaded.");
            }
                
            return BadRequest("Your post could not be uploaded.");
        }

        [HttpGet]
        public async Task<IActionResult> ShowAllPosts()
        {
            var posts = await _postService.ShowAllPostsAsync();
            return Ok(posts);
        }
    }
}
