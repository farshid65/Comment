using CommentApplicatin.Domain.Common;
using CommentApplicatin.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplicatin.Domain.Entities
{
    public class Comment:BaseEntity
    {                

        public string? Content { get;  set; }
        public CommentStatus CommentStatus { get; private set; }
        public virtual ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();
        //public List<Post> Posts { get; }
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
