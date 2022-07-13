using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneDay.Models.Post;

namespace OneDay.Services.Post
{
    public interface IPostService
    {
        Task<bool> CreateNewPostAsync(PostNew post);
        Task<IEnumerable<PostDetail>> ShowAllPostsAsync();
    }
}