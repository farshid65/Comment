using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Posts.GetPosts
{
    public class GetPostsQueryResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}
