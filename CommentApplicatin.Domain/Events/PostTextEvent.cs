using CommentApplicatin.Domain.Common;
using CommentApplicatin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplicatin.Domain.Events
{
    public class PostTextEvent:BaseEvent
    {
        public PostTextEvent(Post text)
        {
            Text = text;
        }
        public Post Text { get; set; }
    }
}
