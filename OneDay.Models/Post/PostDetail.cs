using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneDay.Models.Post
{
    public class PostDetail
    {
         public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTimeOffset DatePosted { get; set; }
    }
}