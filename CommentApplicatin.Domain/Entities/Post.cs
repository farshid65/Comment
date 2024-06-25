using CommentApplicatin.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplicatin.Domain.Entities
{
    public class Post:BaseEntity
    {
        public string Title { get; set; }

        public string? Content { get; set; }

        //public ICollection<Comment> Comments { get; }
        public virtual ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();

        public Guid UserId { get; set; }

        public User User { get; set; }

    }
}
