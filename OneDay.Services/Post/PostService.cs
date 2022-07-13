using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneDay.Models.Post;
using OneDay.Data;
using Microsoft.EntityFrameworkCore;

namespace OneDay.Services.Post
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateNewPostAsync(PostNew post)
        {
            var postEntity = new PostEntity
            {
                Title = post.Title,
                Content = post.Content,
                DatePosted = DateTimeOffset.Now,
            };
            _context.Posts.Add(postEntity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<PostDetail>> ShowAllPostsAsync()
        {
            var posts = await _context.Posts
                .Select(entity => new PostDetail
                {
                Id = entity.Id,
                Title = entity.Title,
                Content = entity.Content,
                DatePosted = entity.DatePosted
                })
                .ToListAsync();
            return posts;
        }
    }
}