using CommentApplicatin.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplicatin.Domain.Entities
{
    public class PostComment
    {
       
        public Guid PostsId { get; set; }
        public Post Post { get; set; }
        public Guid CommentsId { get; set; }
        public Comment Comment { get; set; } 
    }
}
